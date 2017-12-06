﻿using System;
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
        public delegate void ErrorObserver(string errorMessage);
        public delegate void MessageObserver(Event messageData);

        private WebSocket ws;
        private EventTypes sentEventType;

        public static event ErrorObserver eObs;
        public static event MessageObserver mObs;
        public NetworkHandler(string IP)
        {
            //eObs = Broadcast;
            string toPass = "ws://" + IP + ":8001/chatApp";
            ws = new WebSocket(toPass);
            ws.OnMessage += ReceiveFromServer;
            ws.Connect();
        }

        private void BroadcastError(string errorMessage)
        {
            eObs?.Invoke(errorMessage);
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
                        eObs?.Invoke(response.ErrorMessage);
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
