using FP_Server.Controller;
using System;
using System.Collections.Generic;
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
            var wss = new WebSocketServer(8000);

            ServerView serverView = new ServerView();

            wss.AddWebSocketService("/chatApp", () =>
            {
                return new ServerController(serverView.LogServerEvent);
            });

            wss.Start();


            serverView.LogServerEvent("Server has started", LoggerMessageTypes.Success);

            Application.Run(serverView);

            wss.Stop();
        }
    }
}
