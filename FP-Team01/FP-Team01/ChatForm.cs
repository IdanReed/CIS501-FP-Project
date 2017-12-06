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
using FP_Core.Extensions;

namespace FP_Team01
{
    public partial class ChatForm : Form
    {
        public int ChatroomIndex;
        public ChatForm()
        {
            InitializeComponent();
            NetworkHandler.eObs += ReceiveErrorMessage;
            NetworkHandler.mObs += ReceiveFromServer;
        }

        private void ReceiveErrorMessage(string errMessage)
        {
            MessageBox.Show(errMessage);
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

        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            //Show message box with place to put name of contact to add and make sure it is a mutual friend
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            //Send event to server saying logged off and close ChatForm and open MainMenu form

            //From https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            /*this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.FormClosed += (s, args) => this.Close();
            mainMenu.Show();*/
            Form_Closing(sender, null);
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {

        }

        private void uxTBMessage_KeyPress(object sender, KeyPressEventArgs e)//Enter Key on the Send Message box
        {
            if (e.KeyChar.Equals('\r'))//Captures the enter key
            {
                //enter key is down
                //Activate send event
                SendMessage(uxTBMessage.Text);
            }
        }


        private void SendMessage(string msg)
        {
            uxTBMessage.Text = "";
            DateTime localDate = DateTime.Now;
            string name = Program.USERNAME;

            SendMessageEventData newMessage = new SendMessageEventData(name, msg, localDate, ChatroomIndex);
            Event newEvent = new Event(newMessage, EventTypes.SendMessageEvent);
            Program.networkHandler.SendToServer(newEvent);
        }

        public void ReceiveMessage(SendMessageEventData messageData)
        {
            uxtxtChat.AppendTextFormatted(messageData.Username, FontStyle.Bold, GetNameColor(messageData.Username))
                     .AppendTextFormatted(" ", FontStyle.Regular, Color.Black)
                     .AppendTextFormatted(messageData.Time.ToString(), FontStyle.Italic, Color.Black)
                     .AppendTextFormatted(" : ", FontStyle.Regular, Color.Black)
                     .AppendTextFormatted(messageData.Message, FontStyle.Regular, Color.Black)
                     .EndLine();
        }

        public Color GetNameColor(string name)
        {
            int red = (name.Length * 123 + 43 / 3) % 200;
            int blue = 0;
            for (int i = 0; i < name.Length; i++)
            {
                blue += (int)name[i] * 57;
            }
            blue %= 200;
            int green = (red * 3 + blue * 4 / 3) % 200;
            Color newColor = Color.FromArgb(red, blue, green);
            return newColor;
        }

        public void ReceiveFromServer(Event evt)
        {
            if (evt.Type.Equals(EventTypes.SendMessageEvent))
            {
                SendMessageEventData rcdMsg = evt.Data as SendMessageEventData;
                ReceiveMessage(rcdMsg);
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Program.clientState = Program.ClientStates.removeChatroom;
            Program.SwitchForm(this);
        }

        public void UpdateContactLB()
        {
            List<string> contactUsernames = new List<string>();
            foreach (ClientAccount contact in Program.allContacts)
            {
                if (contact.IsOnline)
                {
                    contactUsernames.Add(contact.Username);
                }
            }
            uxLbContacts.DataSource = contactUsernames.ToList();
            this.Invalidate();
        }
    }
}
