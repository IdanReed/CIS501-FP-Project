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
    public partial class MainMenu : Form
    {
        string Username;
        public MainMenu()
        {
            Username = Program.USERNAME;
            InitializeComponent();
            uxLabelName.Text = "Welcome, " + Username + ".";
            NetworkHandler.eObs += ReceiveErrorMessage;
            NetworkHandler.mObs += ReceiveFromServer;
        }

        private void ReceiveErrorMessage(string GUI, string errMessage)
        {
            if (GUI == "Main")
            {
                MessageBox.Show(errMessage);
            }
        }

        private void BtnAddContact_Click(object sender, EventArgs e)
        {

        }

        private void BtnRemoveContact_Click(object sender, EventArgs e)
        {

        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            //Send signout event to server and return to login window, where you can safely close program
            /*this.Close();
            Environment.Exit(0);*/
            Program.clientState = Program.ClientStates.notLoggedIn;
            this.Close();
        }

        private void BtnStartChat_Click(object sender, EventArgs e)
        {
            string contactName = uxLBContacts.SelectedItem.ToString();
            //Send friend name to server and start chat form

            //From https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            /*this.Hide();
            var chat = new ChatForm();
            chat.FormClosed += (s, args) => this.Close();
            chat.Show();*/
            Program.clientState = Program.ClientStates.inChatroom;
            this.Close();
        }

        public void ReceiveFromServer(Event evt)
        {

        }

        public bool ShowYesNoDialogBox()
        {
            //Use this for things like "PersonA wants to be a contact. Add them?"
            //or "PersonA wants you to join a chatroom. Join?"
            DialogResult dialogResult = MessageBox.Show("Do you want to do a thing", "501 Chat", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        private void uxTxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void uxTxtUsername_MouseUp(object sender, MouseEventArgs e)
        {
            uxTxtUsername.Text = "";
        }
    }
}
