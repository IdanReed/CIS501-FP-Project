﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FP_Core.Events;
using FP_Core.Extensions;

namespace FP_Team01
{
    public partial class ChatForm : Form
    {
        int ChatroomIndex;
        public ChatForm()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            //Send message to group
        }

        private void BtnSeeMembers_Click(object sender, EventArgs e)
        {
            //Show message box with current members in the chatroom
        }

        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            //Show message box with place to put name of contact to add and make sure it is a mutual friend
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            //Send event to server saying logged off and close ChatForm and open MainMenu form

            //From https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.FormClosed += (s, args) => this.Close();
            mainMenu.Show();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {

        }

        private void uxTBMessage_KeyPress(object sender, KeyPressEventArgs e)//Enter Key on the Send Message box
        {
            if (e.KeyChar.Equals(Keys.Enter))
            {
                //enter key is down
                //Activate send event
                SendMessage(uxTBMessage.Text);
            }
        }


        private void SendMessage(string msg)
        {
            DateTime localDate = DateTime.Now;
            string name = Program.USERNAME;

            SendMessageEventData newMessage = new SendMessageEventData(name, msg, localDate, ChatroomIndex);
            Event newEvent = new Event(newMessage, EventTypes.SendMessageEvent);
            Program.networkHandler.SendToServer(newEvent);
        }

        public void ReceiveMessage(SendMessageEventData messageData)
        {

        }
    }
}
