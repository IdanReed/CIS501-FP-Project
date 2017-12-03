using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP_Core.Events;
using Newtonsoft.Json;
using WebSocketSharp;

namespace FP_Team01
{
    class NetworkHandler
    {
        public delegate void ErrorObserver(string GUI, string errorMessage);
        public delegate void MessageObserver(Event messageData);

        private WebSocket ws;
        private EventTypes sentEventType;

        public static event ErrorObserver eObs;
        public static event MessageObserver mObs;
        public NetworkHandler()
        {
            //eObs = Broadcast;
            ws = new WebSocket("ws://127.0.0.1:8001/chatApp");
            ws.OnMessage += ReceiveFromServer;
            ws.Connect();
        }

        private void BroadcastError(string GUI, string errorMessage)
        {
            eObs?.Invoke(GUI, errorMessage);
            //others do eObs += Broadcast;
            //where Broadcast is their method to handle stuff
        }

        private void ReceiveFromServer(object sender, MessageEventArgs e)
        {
            bool sentError = false;
            Event evt = JsonConvert.DeserializeObject<Event>(e.Data);

            switch (evt.Type)
            {
                case EventTypes.ServerResponse:
                    ServerResponseEventData response = evt.GetData<ServerResponseEventData>();

                    if (!response.WasSuccessful)
                    {
                        /*
                         * I think right here would be the place that we want to be using a state machine.
                         * You already kinda are by using the sentEventType, but maybe we should make it a more
                         * explicit type a state variable that can be something like loggingInWait, idle, addContactWait. Stuff like that
                         */
                        sentError = true;
                        string errMessage = response.ErrorMessage;
                        switch (sentEventType)
                        {
                            case EventTypes.CreateAccountEvent:
                                BroadcastError("login", errMessage);
                                break;

                            case EventTypes.LoginEvent:
                                BroadcastError("login", errMessage);
                                break;

                            case EventTypes.AddContactEvent:
                                BroadcastError("Main", errMessage);
                                break;

                            case EventTypes.RemoveContactEvent:
                                BroadcastError("Main", errMessage);
                                break;

                            case EventTypes.CreateChatEvent:
                                BroadcastError("Main", errMessage);
                                break;
                        }
                    }
                break;
            }
            if (!sentError)
            {
                mObs?.Invoke(evt);
            }
        }

        public bool SendToServer(Event e)
        {
            sentEventType = e.Type;
            ws.Send(JsonConvert.SerializeObject(e));
            return true;
        }
    }
}
