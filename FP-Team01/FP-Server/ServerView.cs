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
using FP_Core.Extensions;

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
                        uxServerLogBox.AppendTextFormatted("SUCCESS! ", FontStyle.Bold, Color.Green)
                                      .AppendTextFormatted(message, FontStyle.Regular, Color.Black)
                                      .EndLine();
                        break;
                    }
                case LoggerMessageTypes.Error:
                    {
                        uxServerLogBox.AppendTextFormatted("ERROR! ", FontStyle.Bold, Color.Red)
                                      .AppendTextFormatted(message, FontStyle.Regular, Color.Black)
                                      .EndLine();
                        break;
                    }
                case LoggerMessageTypes.UserJoined:
                    {
                        uxServerLogBox.AppendTextFormatted(message, FontStyle.Bold, Color.Blue)
                                      .AppendTextFormatted(" has come online", FontStyle.Regular, Color.Black)
                                      .EndLine();
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
