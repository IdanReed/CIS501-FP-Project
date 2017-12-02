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
            //Send signout event to server through NetworkHandler
            this.Close();
            Environment.Exit(0);
        }

        private void BtnStartChat_Click(object sender, EventArgs e)
        {
            string contactName = uxLBContacts.SelectedItem.ToString();
            //Send friend name to server and start chat form

            //From https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            this.Hide();
            var chat = new ChatForm();
            chat.FormClosed += (s, args) => this.Close();
            chat.Show();
        }

        public void ReceiveFromServer(Event evt)
        {

        }
    }
}
