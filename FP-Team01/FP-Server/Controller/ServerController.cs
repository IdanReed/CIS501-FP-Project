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
        
        public ServerController(Logger logger)
        {
            _logger = logger;
        }

        protected override void OnOpen()
        {
        }

        protected override void OnMessage(MessageEventArgs e)
        {
        }
    }
}
