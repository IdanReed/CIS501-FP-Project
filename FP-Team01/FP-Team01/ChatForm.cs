/*ChatForm 
 *Chat form sends/recieves messages to the server and allows mutual
 *contacts to chat with eachother
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
using FP_Core.Extensions;

namespace FP_Team01
{
    public partial class ChatForm : Form
    {
        public int ChatroomIndex;
        private List<SendMessageEventData> messageLog = new List<SendMessageEventData>();

        public ChatForm()
        {
            InitializeComponent();
            NetworkHandler.eObs += ReceiveErrorMessage;
            NetworkHandler.mObs += ReceiveFromServer;
        }

        /// <summary>
        /// Receives error from the server
        /// </summary>
        /// <param name="errMessage"></param>
        private void ReceiveErrorMessage(string errMessage)
        {
            MessageBox.Show(errMessage);
        }

        /// <summary>
        /// Sends a message to the SendMessage function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSend_Click(object sender, EventArgs e)
        {
            //Send message to group
            SendMessage(uxTBMessage.Text);
        }

        private void BtnSeeMembers_Click(object sender, EventArgs e)
        {
            //Show message box with current members in the chatroom
        }

        /// <summary>
        /// Invites a contact to the chatroom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            //Show message box with place to put name of contact to add and make sure it is a mutual friend
            string contactName = uxLbContacts.SelectedItem.ToString();

            
            //invite contact to current server
            JoinChatroomEventData evtData = new JoinChatroomEventData(contactName, ChatroomIndex, messageLog);
            Event evt = new Event(evtData, EventTypes.CreateChatEvent);
            SendToServer(evt);
        }

        /// <summary>
        /// Signs the user out from the chatroom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatForm_Load(object sender, EventArgs e)
        {
            UpdateContactLB(); 
        }

        /// <summary>
        /// Captures the enter key and sends a message to the send message function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxTBMessage_KeyPress(object sender, KeyPressEventArgs e)//Enter Key on the Send Message box
        {
            if (e.KeyChar.Equals('\r'))//Captures the enter key
            {
                //enter key is down
                //Activate send event
                SendMessage(uxTBMessage.Text);
            }
        }

        /// <summary>
        /// sends a message to the server
        /// </summary>
        /// <param name="msg"></param>
        private void SendMessage(string msg)
        {
            uxTBMessage.Text = "";
            DateTime localDate = DateTime.Now;
            string name = Program.USERNAME;

            SendMessageEventData newMessage = new SendMessageEventData(name, msg, localDate, ChatroomIndex);
            Event newEvent = new Event(newMessage, EventTypes.SendMessageEvent);
            Program.networkHandler.SendToServer(newEvent);
        }

        /// <summary>
        /// Recieves a message from the server
        /// </summary>
        /// <param name="messageData"></param>
        public void ReceiveMessage(SendMessageEventData messageData)
        {
            Action a = new Action(() =>
            {
                uxtxtChat.AppendTextFormatted(messageData.Username, FontStyle.Bold, GetNameColor(messageData.Username))
                     .AppendTextFormatted(" ", FontStyle.Regular, Color.Black)
                     .AppendTextFormatted(messageData.Time.ToString(), FontStyle.Italic, Color.Black)
                     .AppendTextFormatted(" : ", FontStyle.Regular, Color.Black)
                     .AppendTextFormatted(messageData.Message, FontStyle.Regular, Color.Black)
                     .EndLine();
            });

            if (InvokeRequired) Invoke(a);
            else a();

        }

        /// <summary>
        /// Generates a color for the user based off of their name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Receive an event from the server
        /// </summary>
        /// <param name="evt"></param>
        public void ReceiveFromServer(Event evt)
        {
            if (evt.Type == EventTypes.SendMessageEvent)
            {
                SendMessageEventData rcdMsg = evt.GetData<SendMessageEventData>();
                if (rcdMsg.ChatRoomIndex != ChatroomIndex) return;
                ReceiveMessage(rcdMsg);
                messageLog.Add(rcdMsg);
            }
            else if(evt.Type.Equals(EventTypes.JoinedChatEvent))
            {
                JoinChatroomEventData rcdMsg = evt.GetData<JoinChatroomEventData>();
                if (rcdMsg.messageLog == null) return;
                foreach(SendMessageEventData msgData in rcdMsg.messageLog)
                {
                    if (msgData.ChatRoomIndex != ChatroomIndex) return;
                    ReceiveMessage(msgData);
                    messageLog.Add(msgData);
                }
            }
        }

        /// <summary>
        /// captures the closing of the form and logs out safely
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            LeaveChatroomEventData newMessage = new LeaveChatroomEventData(Program.USERNAME, ChatroomIndex ); 
            Event newEvent = new Event(newMessage, EventTypes.LeaveChatEvent);
            Program.networkHandler.SendToServer(newEvent);

            Program.clientState = Program.ClientStates.removeChatroom;
            Program.SwitchForm(this);
        }

        /// <summary>
        /// Updates the contact list box
        /// </summary>
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

        /// <summary>
        /// Sends an event to the server
        /// </summary>
        /// <param name="evt"></param>
        public void SendToServer(Event evt)
        {
            Program.networkHandler.SendToServer(evt);
        }
    }
}
