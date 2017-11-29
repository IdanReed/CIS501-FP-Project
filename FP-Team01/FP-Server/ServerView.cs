using FP_Server.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_Server
{
    public partial class ServerView : Form
    {
        public ServerView()
        {
            InitializeComponent();
        }

        public void LogServerEvent(string message, LoggerMessageTypes type)
        {

            //This was required because of an error I was getting where I was trying
            //to use the ui elements from a different thread.
            if (InvokeRequired)
            {
                Invoke(new Action(() => _Logger(message, type)));
            }
            else
            {
                _Logger(message, type);
            }
        }
        private void _Logger(string message, LoggerMessageTypes type)
        {
            switch (type)
            {
                case LoggerMessageTypes.Success:
                    {
                        uxServerLogBox.ForeColor = Color.Green;
                        uxServerLogBox.AppendText("SUCESS! " + message + "\n");
                        break;
                    }
                case LoggerMessageTypes.Error:
                    {
                        uxServerLogBox.ForeColor = Color.Red;
                        uxServerLogBox.AppendText("ERROR! " + message + "\n");
                        break;
                    }
                case LoggerMessageTypes.UserJoined:
                    {
                        uxServerLogBox.ForeColor = Color.Blue;
                        uxServerLogBox.AppendText(message);
                        uxServerLogBox.ForeColor = Color.Black;
                        uxServerLogBox.AppendText(" has come online\n");
                        break;
                    }
                default:
                    {
                        uxServerLogBox.AppendText(message + "\n");
                        break;
                    }
            }
        }
    }
}
