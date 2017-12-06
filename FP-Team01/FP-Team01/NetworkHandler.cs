/*NetworkHandler 
 *NetworkHandler interfaces with the server
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP_Core.Events;
using Newtonsoft.Json;
using WebSocketSharp;
using System.Threading;

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
            ws.OnClose += (sender, e) =>
            {
                Thread.Sleep(1000);
                ws.Connect();
                TempConnectTest();
            };
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
                        sentError = true;
                        eObs?.Invoke(response.ErrorMessage);
                    }
                break;
            }
            if (!sentError && evt.Type != EventTypes.ServerResponse)
            {
                mObs?.Invoke(evt);
                //new Thread(() => mObs?.Invoke(evt)).Start();
            }
        }

        public bool SendToServer(Event e)
        {
            sentEventType = e.Type;
            ws.Send(JsonConvert.SerializeObject(e));
            return true;
        }

        private void TempConnectTest()
        {
            Event evt = new Event(Program.USERNAME, EventTypes.SendAllContacts);
            SendToServer(evt);
        }
    }
}
