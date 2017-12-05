using FP_Core.Events;
using FP_Server.Controller;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;

namespace FP_Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var wss = new WebSocketServer(8001);

            ServerView serverView = new ServerView();
            ServerController controller = new ServerController(serverView.LogServerEvent);

            wss.AddWebSocketService("/chatApp", () =>
            {
                ServerSocketBehavior behavior = new ServerSocketBehavior();
                behavior.OnCloseEvent += controller.OnClose;
                behavior.OnOpenEvent += controller.OnOpen;
                behavior.OnMessageEvent += controller.OnMessage;

                return behavior;
            });

            wss.Start();
            
            serverView.LogServerEvent("Server has started", LoggerMessageTypes.Success);
            controller.Updater += serverView.Update;

            Application.Run(serverView);

            wss.Stop();
        }
    }
}
