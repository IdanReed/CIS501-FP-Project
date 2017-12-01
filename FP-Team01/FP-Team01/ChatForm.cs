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
            SendMessage(uxTBMessage.Text);
        }

        private void BtnSeeMembers_Click(object sender, EventArgs e)
        {
            //Show message box with current members in the chatroom
        }

        private void BtnAddContact_Click(object sender, EventArgs e)//This really should be an invite friends thing
        {
            //Show message box with place to put name of contact to add and make sure it is a mutual friend
            
            Event invitedContact = (Event)uxLbContacts.SelectedItem;
            //Send request to the server
            Program.networkHandler.SendToServer(invitedContact);

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
            uxtxtChat.AppendTextFormatted(messageData.Username, FontStyle.Bold, Color.Red)
                     .AppendTextFormatted(" ", FontStyle.Regular, Color.Black)
                     .AppendTextFormatted(messageData.Time.ToString(), FontStyle.Italic, Color.Black)
                     .AppendTextFormatted(" : ", FontStyle.Regular, Color.Black)
                     .AppendTextFormatted(messageData.Message, FontStyle.Regular, Color.Black)
                     .EndLine();
        }

        public void ReceiveOnlineContacts(List<string> onlineContacts)//Change string to Contact Data type
        {
            uxLbContacts.DataSource = onlineContacts;
        }
    }
}
