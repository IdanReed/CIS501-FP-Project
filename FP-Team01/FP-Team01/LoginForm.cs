using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FP_Core.Events;

namespace FP_Team01
{
    public partial class LoginForm : Form
    {
        string Username;
        string Password;
        string IP;
        public LoginForm()
        {
            InitializeComponent();
            NetworkHandler.eObs += ReceiveErrorMessage;
            NetworkHandler.mObs += ReceiveFromServer;
        }

        private void ReceiveErrorMessage(string errMessage)
        {
            MessageBox.Show(errMessage);
        }

        private void BtnCreateAcct_Click(object sender, EventArgs e)
        {
            Username = uxTBUsername.Text;
            Password = uxTBPassword.Text;
            IP = uxTxtIp.Text;
            Program.CreateNetwork(IP);
            CreateAccountEventData createEvent = new FP_Core.Events.CreateAccountEventData(Username, Password);
            Event toSend = new Event(createEvent, EventTypes.CreateAccountEvent);
            Program.networkHandler.SendToServer(toSend);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Username = uxTBUsername.Text;
            Password = uxTBPassword.Text;
            IP = uxTxtIp.Text;
            //Program.serverIP = IP;
            Program.CreateNetwork(IP);
            FP_Core.Events.LoginEventData loginEvent = new FP_Core.Events.LoginEventData(Username, Password);
            Event toSend = new Event(loginEvent, EventTypes.LoginEvent);
            Program.networkHandler.SendToServer(toSend);
        }

        public void ReceiveFromServer(Event evt)
        {
            Program.USERNAME = Username;
            Program.PASSWORD = Password;
            //Open main menu GUI

            //From https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            /*this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.FormClosed += (s, args) => this.Close();
            mainMenu.Show();*/
            Program.clientState = Program.ClientStates.Idle;
            Program.SwitchForm(this);
        }

        private void uxLabelWelcome1_Click(object sender, EventArgs e)
        {

        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                Program.clientState = Program.ClientStates.Idle;
            }
            // Do something proper to CloseButton.
            else
            {
                Program.clientState = Program.ClientStates.exitProgram;
            }
            Program.SwitchForm(this);
            // Then assume that X has been clicked and act accordingly.
        }
    }
}
