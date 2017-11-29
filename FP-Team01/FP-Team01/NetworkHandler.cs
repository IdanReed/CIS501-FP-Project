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
        private WebSocket ws;
        public NetworkHandler()
        {
            ws = new WebSocket("ws://127.0.0.1:8001/chatApp");
            ws.OnMessage += ReceiveFromServer;
            ws.Connect();
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
                    }
                    break;
                }
            }
        }

        public bool SendToServer(FP_Core.Events.Event e)
        {
            ws.Send(JsonConvert.SerializeObject(e));
            return true;
        }
    }
}
