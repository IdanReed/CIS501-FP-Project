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
        private WebSocket ws;
        private EventTypes sentEventType;
        public event ErrorObserver eObs;
        public NetworkHandler()
        {
            //eObs = Broadcast;
            ws = new WebSocket("ws://127.0.0.1:8001/chatApp");
            ws.OnMessage += ReceiveFromServer;
            ws.Connect();
        }

        private void Broadcast(string GUI, string errorMessage)
        {
            eObs?.Invoke("", "");
            //others do eObs += Broadcast;
            //where Broadcast is their method to handle stuff
        }

        private void ReceiveFromServer(object sender, MessageEventArgs e)
        {
            Event evt = JsonConvert.DeserializeObject<Event>(e.Data);

            switch (evt.Type)
            {
                case EventTypes.ServerResponse:
                {
                    ServerResponseEventData response = evt.GetData<ServerResponseEventData>();

                    if (!response.WasSuccessful)
                    {
                        //MessageBox.Show(response.ErrorMessage);
                        string errMessage = response.ErrorMessage;
                        switch (sentEventType)
                        {
                            case EventTypes.CreateAccountEvent:
                            {
                                
                                break;
                            }
                        }
                    }
                    break;
                }
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
