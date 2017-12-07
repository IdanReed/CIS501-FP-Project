using FP_Core;
using FP_Core.Events;
using FP_Server.Controller;
using FP_Server.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace FP_Server.Controller
{
    public delegate void Update(List<Account> sgf, List<ChatRoom> adf);
    public delegate void Logger(string message, LoggerMessageTypes type);
    class ServerController 
    {
        private enum ServerStates
        {
            NotReady,
            Started,
            DataLoaded,
            Exiting
        }
        private ServerStates _state = ServerStates.NotReady;

        public const string FILE_PATH = "./data.txt";
        private Logger _logger;

        private List<Account> _accounts;
        private List<ChatRoom> _rooms;
        private int _currentRoomID = 0;

        public event Update Updater;
        
        public ServerController(Logger logger)
        {
            _accounts = new List<Account>();
            _rooms = new List<ChatRoom>();
            _logger = logger;
        }
        ~ServerController()
        {
            _state = ServerStates.Exiting;
            _WriteData();
        }

        private void _WriteData()
        {
            StreamWriter sw = new StreamWriter(FILE_PATH);

            JsonSerializerSettings sets = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ContractResolver = new MyContractResolver()
                //TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            };

            string data = JsonConvert.SerializeObject(_accounts, sets);

            sw.WriteLine(data);
            sw.Close();
        }

        public void LoadData()
        {
            try
            {
                StreamReader sr = new StreamReader(FILE_PATH);

                string data = sr.ReadToEnd();

                List<Account> accountData = JsonConvert.DeserializeObject<List<Account>>(data, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    
                    ContractResolver = new MyContractResolver()
                });
                if (accountData != null)
                {
                    _accounts = accountData;
                    Updater?.Invoke(_accounts, _rooms);
                }
            }
            catch(FileNotFoundException e)
            {
                _logger("No data file found, creating a new one", LoggerMessageTypes.None);
            }
            _state = ServerStates.DataLoaded;
        }
        public void OnOpen(ServerSocketBehavior sender)
        {
            _logger("A client has connected to the server", LoggerMessageTypes.None);

            if (_state == ServerStates.DataLoaded) _state = ServerStates.Started;
        }

        public void OnMessage(ServerSocketBehavior sender, MessageEventArgs e)
        {
            if (_state == ServerStates.Started)
            {
                Event evt = JsonConvert.DeserializeObject<Event>(e.Data);

                switch (evt.Type)
                {
                    #region Account Handlers

                    case EventTypes.NewWSClient:
                        {
                            string uName = e.Data as string;

                            Account loginAccount = _accounts.Find(a => a.Username == uName);
                            if (loginAccount != null && sender != null)
                            {
                                loginAccount.Socket = sender;
                            }

                            break;
                        }
                    case EventTypes.CreateAccountEvent:
                        {
                            CreateAccountEventData data = evt.GetData<CreateAccountEventData>();

                            ServerResponseEventData response;
                            try
                            {
                                _CreateAccount(data.Username, data.Password);
                                _TryLogin(data.Username, data.Password, sender);

                                response = new ServerResponseEventData();
                                _logger("Account with username '" + data.Username + "' was created", LoggerMessageTypes.Success);
                            }
                            catch (ArgumentException err)
                            {
                                response = new ServerResponseEventData(err.Message);

                                _logger("Client attempted to create an account and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                            }
                            sender.SendToSocket(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));
                            break;
                        }
                    case EventTypes.LoginEvent:
                        {
                            LoginEventData data = evt.GetData<LoginEventData>();

                            ServerResponseEventData response;

                            try
                            {
                                _TryLogin(data.Username, data.Password, sender);
                                response = new ServerResponseEventData();

                                _logger("Account with username '" + data.Username + "' has successfully logged in", LoggerMessageTypes.None);
                            }
                            catch (ArgumentException err)
                            {
                                response = new ServerResponseEventData(err.Message);

                                _logger("Client attempted to login with username '" + data.Username + "' and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                            }
                            sender.SendToSocket(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));

                            break;
                        }
                    case EventTypes.AddContactEvent:
                        {
                            SendContactEventData data = evt.GetData<SendContactEventData>();

                            ServerResponseEventData response;

                            try
                            {
                                _AddContact(sender, data.Username);

                                response = new ServerResponseEventData();
                                _logger("Account has added a contact with username '" + data.Username + "' to their contact list", LoggerMessageTypes.None);
                            }
                            catch (ArgumentException err)
                            {
                                response = new ServerResponseEventData(err.Message);

                                _logger("Account attempted to add account with username '" + data.Username + "' and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                            }
                            sender.SendToSocket(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));

                            break;
                        }
                    case EventTypes.RemoveContactEvent:
                        {
                            SendContactEventData data = evt.GetData<SendContactEventData>();


                            try
                            {
                                _RemoveContact(sender, data.Username);

                                _logger("Client removed contact with username '" + data.Username + "'", LoggerMessageTypes.None);
                                _SendAllContacts(_accounts.Find(a => a.Username == data.Username));
                                _SendAllContacts(_accounts.Find(a => a.Socket == sender));
                                //response = new ServerResponseEventData();
                            }
                            catch (ArgumentException err)
                            {
                                ServerResponseEventData response;
                                response = new ServerResponseEventData(err.Message);

                                _logger("Client attempted to remove contact with username '" + data.Username + "' and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                                sender.SendToSocket(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));
                            }
                            break;
                        }
                    case EventTypes.LogoutEvent:
                        {
                            LogoutEventData data = evt.GetData<LogoutEventData>();


                            try
                            {
                                _TryLogout(data.Username, sender);

                                // response = new ServerResponseEventData();
                                _logger("Account with username '" + data.Username + "' has logged out", LoggerMessageTypes.None);
                            }
                            catch (ArgumentException err)
                            {
                                // response = new ServerResponseEventData(err.Message);

                                _logger("Client attempted to logout with username '" + data.Username + "' and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                            }
                            // sender.SendToSocket(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));
                            break;
                        }
                    case EventTypes.SendAllContacts:
                        {
                            string username = (string)evt.Data;

                            _SendAllContacts(_accounts.Find(a => a.Username == username));

                            break;
                        }

                    #endregion

                    #region Chatroom Handlers

                    case EventTypes.CreateChatEvent:
                        {
                            JoinChatroomEventData data = evt.GetData<JoinChatroomEventData>();

                            if (data.id > -1)
                            {
                                try
                                {
                                    string senderUsername = _accounts.Find(a => a.Socket == sender)?.Username;
                                    _JoinExisitingChat(data.id, data.Username);


                                    ChatRoom room = _rooms.Find(r => r.RoomID == data.id);
                                    foreach(Account participant in room.Participants)
                                    {
                                        JoinChatroomEventData response = new JoinChatroomEventData(senderUsername, data.id);
                                        if (data.messageLog != null && data.messageLog.Count > 0 && participant.Username == data.Username) response.messageLog = data.messageLog;
                                        string eventData = JsonConvert.SerializeObject(new Event(response, EventTypes.JoinedChatEvent));
                                        participant.Socket.SendToSocket(eventData);
                                    }
                                }
                                catch(ArgumentException err)
                                {
                                    ServerResponseEventData response = new ServerResponseEventData(err.Message);
                                    sender.SendToSocket(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));
                                    _logger("Client attempted to add a user, '" + data.Username + "', to chat room '" + data.id + "' and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                                }
                            }
                            else
                            {
                                try
                                {
                                    int roomId = _CreateChatroom(data.Username, sender);

                                    string senderUsername = _accounts.Find(a => a.Socket == sender)?.Username;
                                    Account recieverAccount = _accounts.Find(a => a.Username == data.Username);

                                    JoinChatroomEventData response = new JoinChatroomEventData(senderUsername, roomId);
                                    string eventData = JsonConvert.SerializeObject(new Event(response, EventTypes.JoinedChatEvent));
                                    sender.SendToSocket(eventData);
                                    recieverAccount.Socket.SendToSocket(eventData);
                                    _logger("Two users have created a chatroom with eachother", LoggerMessageTypes.None);
                                }
                                catch (ArgumentException err)
                                {
                                    ServerResponseEventData response = new ServerResponseEventData(err.Message);
                                    sender.SendToSocket(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));
                                    _logger("Client attempted to create a chatroom with a contact whose username is '" + data.Username + "' and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                                }
                            }

                            break;
                        }


                    case EventTypes.LeaveChatEvent:
                        {
                            try
                            {
                                LeaveChatroomEventData data = evt.GetData<LeaveChatroomEventData>();
                                _LeaveChatroom(data.Username, data.ChatroomID);

                                _logger("Client with username '" + data.Username + "' successfully left chatroom '" + data.ChatroomID + "'", LoggerMessageTypes.None);
                            }
                            catch(ArgumentException err)
                            {
                                ServerResponseEventData response = new ServerResponseEventData(err.Message);
                                sender.SendToSocket(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));
                                _logger("Client attempted to leave a chatroom and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                            }

                            break;
                        }
                    case EventTypes.SendMessageEvent:
                        {
                            SendMessageEventData data = evt.GetData<SendMessageEventData>();

                            try
                            {
                                _SendMessageToChatroom(data);

                                _logger("A message was sent to " + data.Username + " at time " + data.Time, LoggerMessageTypes.None);
                            }
                            catch (ArgumentException err)
                            {
                                _logger("Client attempted to send a message to chat room '" + data.ChatRoomIndex + "' and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                            }

                            break;
                        }

                        #endregion
                }

                Updater?.Invoke(_accounts, _rooms);
            }
        }

        public void OnClose(ServerSocketBehavior sender, CloseEventArgs e)
        {
            _logger("A client has left the server", LoggerMessageTypes.None);
        }

        #region Account Handling

        private void _CreateAccount(string username, string password)
        {
            if (_accounts.Exists(a => a.Username == username)) throw new ArgumentException("That username is already taken");

            _accounts.Add(new Account(username, password));
            
        } 

        private void _TryLogin(string username, string password, ServerSocketBehavior socket)
        {
            Account acct = _accounts.Find(a => a.Username == username);
            if(acct == null) throw new ArgumentException("No account with that username exists. Please create an account before logging in");
            if (acct.IsOnline) throw new ArgumentException("User is already logged in");
            else if (acct.Password != password) throw new ArgumentException("Username or password is incorrect");

            acct.IsOnline = true;
            acct.Socket = socket;
            //_SendAllContacts(acct);
            _UpdateOnlineContacts(acct);
        }
        private void _TryLogout(string username, ServerSocketBehavior socket)
        {
            Account acct = _accounts.Find(a => a.Username == username);

            if (acct == null) throw new ArgumentException("No account with that username exists. Cannot logout");
            if (!acct.IsOnline) throw new ArgumentException("User is not logged in, so cannot logout");
            if (acct.Socket != socket) throw new ArgumentException("User not logging out through the same client they logged in with. No Bueno");

            acct.IsOnline = false;

            SendContactEventData offlineData = new SendContactEventData(username);
            Event e = new Event(offlineData, EventTypes.ContactWentOffline);
            string eventString = JsonConvert.SerializeObject(e);

            foreach(Account contact in acct.Contacts)
            {
                if (contact.IsOnline && contact.Socket != null) {
                    contact.Socket.SendToSocket(eventString);
                }
            }
            
        }

        private void _SendAllContacts(Account acct)
        {
            SendAllContactsEventData data = new SendAllContactsEventData(acct.Username);
            data.AllContacts = acct.Contacts.Select(a => Tuple.Create(a.IsOnline, a.Username)).ToList();
            Event e = new Event(data, EventTypes.SendAllContacts);
            string eventData = JsonConvert.SerializeObject(e);

            if (acct.Socket != null)
            {
                acct.Socket.SendToSocket(eventData);
            }
        }

        private void _UpdateOnlineContacts(Account acct)
        {
            List<IAccount> onlineContacts = acct.Contacts.FindAll(a => a.IsOnline);

            SendContactEventData data = new FP_Core.Events.SendContactEventData(acct.Username);
            Event e = new Event(data, EventTypes.ContactWentOnline);
            string eventString = JsonConvert.SerializeObject(e);
            foreach(Account onAcct in onlineContacts)
            {
                if (onAcct.Socket != null)
                {
                    onAcct.Socket.SendToSocket(eventString);
                }
            }
        }

        private void _AddContact(ServerSocketBehavior sender, string username)
        {
            Account senderAcct = _accounts.Find(a => a.Socket == sender);

            if (senderAcct == null) throw new ArgumentException("Could not determine sender! Please try again");

            Account addContact = _accounts.Find(a => a.Username == username);

            if (addContact == null) throw new ArgumentException("No account with username '" + username + "' exists.");
            if (addContact == senderAcct) throw new ArgumentException("Cannot add yourself as a contact");
            if (addContact.Contacts.Contains(senderAcct) || senderAcct.Contacts.Contains(addContact)) throw new ArgumentException("User is already a contact");

            senderAcct.Contacts.Add(addContact);
            addContact.Contacts.Add(senderAcct);

            _SendAllContacts(senderAcct);
            _SendAllContacts(addContact);
        }

        private void _RemoveContact(ServerSocketBehavior sender, string username)
        {
            Account senderAcct = _accounts.Find(a => a.Socket == sender);

            if (senderAcct == null) throw new ArgumentException("Could not determine sender! Please login and try again");

            Account removeCont = _accounts.Find(a => a.Username == username);

            if (removeCont == null) throw new ArgumentException("No account with username '" + username + "' exists.");
            if (removeCont == senderAcct) throw new ArgumentException("Cannot remove yourself as a contact");
            if (!removeCont.Contacts.Contains(senderAcct) || !senderAcct.Contacts.Contains(removeCont)) throw new ArgumentException("User is not a contact of yours");

            senderAcct.Contacts.Remove(removeCont);
            removeCont.Contacts.Remove(senderAcct);

            _UpdateOnlineContacts(senderAcct);
            _UpdateOnlineContacts(removeCont);
        }


        #endregion

        #region Chat Room Handling

        private void _JoinExisitingChat(int roomId, string username)
        {
            Account newParticipant = _accounts.Find(a => a.Username == username);
            if (newParticipant == null) throw new ArgumentException("Account with username '" + username + "' does not exist");
            
            ChatRoom room = _rooms.Find(r => r.RoomID == roomId);
            if (room == null) throw new ArgumentException("Chat room with id '" + roomId + "' does not exist");

            bool isValidParticipant = true;
            foreach(Account a in room.Participants)
            {
                if (!a.Contacts.Contains(newParticipant)) isValidParticipant = false;
            }

            if (!isValidParticipant) throw new ArgumentException("The contact you are trying to add is not contacts with everyone in the chat room");

            room.Participants.Add(newParticipant); 
        }
        private int _CreateChatroom(string username, ServerSocketBehavior sender)
        {
            int chatRoomId = _currentRoomID;
           

            Account acct = _accounts.Find(a => a.Socket == sender);
            if (acct == null) throw new ArgumentException("Cannot determine sender, please login and try again");
            if (acct.Username == username) throw new ArgumentException("Cannot create a chatroom with yourself");

            Account contact = _accounts.Find(a => a.Username == username);
            if (contact == null) throw new ArgumentException("Cannot find account with username '" + username + "' to create a chatroom with");
            if (!contact.IsOnline) throw new ArgumentException("Contact is not online, cannot create a chat with them unless they're online");

            ChatRoom room = new ChatRoom(chatRoomId);
            _rooms.Add(room);

            room.Participants.Add(acct);
            room.Participants.Add(contact);

            _currentRoomID++;

            return chatRoomId;
        }

        private void _LeaveChatroom(string username, int chatroomID)
        {
            Account leavingAccount = _accounts.Find(a => a.Username == username);
            if (leavingAccount == null) throw new ArgumentException("Cannot find account with username '" + username + "'");

            ChatRoom room = _rooms.Find(r => r.RoomID == chatroomID);
            if(room == null) throw new ArgumentException("Cannot find a chat room with id '" + chatroomID + "'");

            room.Participants.Remove(leavingAccount);

            if (room.Participants.Count == 0)
            {
                _rooms.Remove(room);
                _logger("A room was removed because all users had left", LoggerMessageTypes.None);
            }
        }

        private void _SendMessageToChatroom(SendMessageEventData data)
        {
            ChatRoom room = _rooms.Find(r => r.RoomID == data.ChatRoomIndex);
            if (room == null) throw new ArgumentException("No chatroom with ID '" + data.ChatRoomIndex + "' exists");

            if (!room.Participants.Exists(a => a.Username == data.Username)) throw new ArgumentException("User with username '" + data.Username + "' is not a part of chatroom '" + data.ChatRoomIndex + "'");

            Event e = new Event(data, EventTypes.SendMessageEvent);
            string eventString = JsonConvert.SerializeObject(e);

            foreach(Account participant in room.Participants)
            {
                participant.Socket.SendToSocket(eventString);
            }
        }


        #endregion
    }

    public class MyContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(p => base.CreateProperty(p, memberSerialization))
                        .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                   .Select(f => base.CreateProperty(f, memberSerialization)))
                        .ToList();
            props.ForEach(p => { p.Writable = true; p.Readable = true; });
            return props;
        }
    }
}
