/*LoginForm 
 *Handles the creation and logging in of accounts
 * 
 */
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

        /// <summary>
        /// Receives error message from server
        /// </summary>
        /// <param name="errMessage"></param>
        private void ReceiveErrorMessage(string errMessage)
        {
            MessageBox.Show(errMessage);
        }

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateAcct_Click(object sender, EventArgs e)
        {
            Username = uxTBUsername.Text;
            Password = uxTBPassword.Text;
            IP = uxTxtIp.Text;

            try
            {
                Program.CreateNetwork(IP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CreateAccountEventData createEvent = new FP_Core.Events.CreateAccountEventData(Username, Password);
            Event toSend = new Event(createEvent, EventTypes.CreateAccountEvent);
            Program.networkHandler.SendToServer(toSend);
        }

        /// <summary>
        /// Logs in to an existing account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Username = uxTBUsername.Text;
            Password = uxTBPassword.Text;
            IP = uxTxtIp.Text;
            try
            {
                Program.CreateNetwork(IP);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
            FP_Core.Events.LoginEventData loginEvent = new FP_Core.Events.LoginEventData(Username, Password);
            Event toSend = new Event(loginEvent, EventTypes.LoginEvent);
            Program.networkHandler.SendToServer(toSend);
        }

        /// <summary>
        /// Receives an event from the server
        /// </summary>
        /// <param name="evt"></param>
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
            Program.clientState = Program.ClientStates.openMainMenu;
            Program.SwitchForm(this);
        }

        private void uxLabelWelcome1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Switches the state of the program when the login form closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                Program.clientState = Program.ClientStates.openMainMenu;
            }
            // Do something proper to CloseButton.
            else
            {
                Program.clientState = Program.ClientStates.exitProgram;
            }
            Program.SwitchForm(this);
            // Then assume that X has been clicked and act accordingly.
        }

        /// <summary>
        /// Disposes the form when the user presses the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
