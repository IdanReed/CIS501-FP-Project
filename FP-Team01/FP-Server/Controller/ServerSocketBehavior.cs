using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace FP_Server.Controller
{
    public delegate void MessageEvent(ServerSocketBehavior sender, MessageEventArgs args);
    public delegate void CloseMessageEvent(ServerSocketBehavior sender, CloseEventArgs args);
    public delegate void OpenEvent(ServerSocketBehavior sender);
    public class ServerSocketBehavior: WebSocketBehavior
    {
        public event MessageEvent OnMessageEvent;
        public event CloseMessageEvent OnCloseEvent;
        public event OpenEvent OnOpenEvent;

        protected override void OnMessage(MessageEventArgs e)
        {
            OnMessageEvent?.Invoke(this, e);
        }
        protected override void OnClose(CloseEventArgs e)
        {
            OnCloseEvent?.Invoke(this, e);
        }
        protected override void OnOpen()
        {
            OnOpenEvent?.Invoke(this);
        }

        public void SendToSocket(string data)
        {
            Send(data);
            //Sessions.SendTo(ID, data);
        }
    }
}
