using FP_Core.Events;
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
    class ServerController: WebSocketBehavior
    {
        private Logger _logger;

        private List<Account> _accounts;
        private List<ChatRoom> _rooms;
        
        public ServerController(Logger logger)
        {
            _accounts = new List<Account>();
            _logger = logger;
        }

        protected override void OnOpen()
        {
            _logger("A client has connected to the server", LoggerMessageTypes.None);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Event evt = JsonConvert.DeserializeObject<Event>(e.Data);

            switch (evt.Type)
            {
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

                        

                        Sessions.SendTo(ID, JsonConvert.SerializeObject(new Event(response, EventTypes.ServerResponse)));
                        break;
                    }
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            _logger("A client has left the server", LoggerMessageTypes.None);
        }

        #region Account Handling

        private void _CreateAccount(string username, string password)
        {
            if (_accounts.Exists(a => a.Username == username)) throw new ArgumentException("That username is already taken");

            _accounts.Add(new Account(username, password)); 
        } 
        #endregion

    }
}
