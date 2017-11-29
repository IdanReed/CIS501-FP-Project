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
                        uxServerLogBox.SelectionColor = Color.Green;
                        uxServerLogBox.SelectionFont = new Font(uxServerLogBox.Font, FontStyle.Bold);
                        uxServerLogBox.AppendText("SUCCESS! "); 
                        uxServerLogBox.SelectionFont = new Font(uxServerLogBox.Font, FontStyle.Regular);
                        uxServerLogBox.SelectionColor = Color.Black;
                        uxServerLogBox.AppendText(message + "\n");
                        uxServerLogBox.SelectionStart = uxServerLogBox.Text.Length;
                        uxServerLogBox.ScrollToCaret();
                        break;
                    }
                case LoggerMessageTypes.Error:
                    {
                        uxServerLogBox.SelectionColor = Color.Red;
                        uxServerLogBox.SelectionFont = new Font(uxServerLogBox.Font, FontStyle.Bold);
                        uxServerLogBox.AppendText("ERROR! ");
                        uxServerLogBox.SelectionColor = Color.Black;
                        uxServerLogBox.SelectionFont = new Font(uxServerLogBox.Font, FontStyle.Regular);
                        uxServerLogBox.AppendText(message + "\n");
                        uxServerLogBox.SelectionStart = uxServerLogBox.Text.Length;
                        uxServerLogBox.ScrollToCaret();
                        break;
                    }
                case LoggerMessageTypes.UserJoined:
                    {
                        uxServerLogBox.SelectionColor = Color.Blue;
                        uxServerLogBox.SelectionFont = new Font(uxServerLogBox.Font, FontStyle.Bold);
                        uxServerLogBox.AppendText(message);
                        uxServerLogBox.SelectionFont = new Font(uxServerLogBox.Font, FontStyle.Regular);
                        uxServerLogBox.SelectionColor = Color.Black;
                        uxServerLogBox.AppendText(" has come online\n");
                        uxServerLogBox.SelectionStart = uxServerLogBox.Text.Length;
                        uxServerLogBox.ScrollToCaret();
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
