using FP_Core.Events;
using FP_Server.Controller;
using FP_Server.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace FP_Server.Controller
{
    public delegate void Logger(string message, LoggerMessageTypes type);
    class ServerController 
    {
        private Logger _logger;

        private List<Account> _accounts;
        private List<ChatRoom> _rooms;
        
        public ServerController(Logger logger)
        {
            _accounts = new List<Account>();
            _logger = logger;
        }

        public void OnOpen(ServerSocketBehavior sender)
        {
            _logger("A client has connected to the server", LoggerMessageTypes.None);
        }

        public void OnMessage(ServerSocketBehavior sender, MessageEventArgs e)
        {
            Event evt = JsonConvert.DeserializeObject<Event>(e.Data);

            switch (evt.Type)
            {
                #region Account Handlers
                case EventTypes.CreateAccountEvent:
                    {
                        CreateAccountEventData data = evt.GetData<CreateAccountEventData>();

                        ServerResponseEventData response;
                        try
                        {
                            _CreateAccount(data.Username, data.Password);
                            response = new ServerResponseEventData();

                            _logger("Account with username '" + data.Username+"' was created", LoggerMessageTypes.Success);
                        }
                        catch(ArgumentException err)
                        {
                            response = new ServerResponseEventData(err.Message);

                            _logger("Client attempted to create an account and an error was thrown: "+err.Message, LoggerMessageTypes.Error);
                        }
                        sender.Send(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));
                        break;
                    }
                case EventTypes.LoginLogoutEvent:
                    {
                        LoginLogoutEventData data = evt.GetData<LoginLogoutEventData>();

                        ServerResponseEventData response;

                        try
                        {
                            _TryLogin(data.Username, data.Password);
                            response = new ServerResponseEventData();

                            _logger("Account with username '" + data.Username + "' has successfully logged in", LoggerMessageTypes.None);
                        }
                        catch(ArgumentException err)
                        {
                            response = new ServerResponseEventData(err.Message);

                            _logger("Client attempted to login with username '"+ data.Username+"' and an error was thrown: " + err.Message, LoggerMessageTypes.Error);
                        }
                        sender.Send(JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));

                        break;
                    }
                    #endregion
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

        private void _TryLogin(string username, string password)
        {
            Account acct = _accounts.Find(a => a.Username == username);
            if(acct == null) throw new ArgumentException("No account with that username exists. Please create an account before logging in");
            if (acct.IsOnline) throw new ArgumentException("User is already logged in");
            else if (acct.Password != password) throw new ArgumentException("Username or password is incorrect");

            acct.IsOnline = true;
        }
        #endregion

    }
}
