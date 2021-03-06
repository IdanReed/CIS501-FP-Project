﻿/*Main Menu
 *Main Menu handles the adding of contacts and creating of chatrooms
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
using FP_Core;
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
            Event getAllContacts = new Event(Username, EventTypes.SendAllContacts);
            SendToServer(getAllContacts);
        }

        /// <summary>
        /// Revieves error message from the server
        /// </summary>
        /// <param name="errMessage"></param>
        private void ReceiveErrorMessage(string errMessage)
        {
            //MessageBox.Show(Program.USERNAME + ": " + errMessage);
        }

        /// <summary>
        /// Requests the server to add a contact from the given username
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            string contactToAdd = uxTxtUsername.Text;
            SendContactEventData evtData = new SendContactEventData(contactToAdd);
            Event evt = new Event(evtData, EventTypes.AddContactEvent);
            SendToServer(evt);
        }

        /// <summary>
        /// Requests the server to remove a contact given the username
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveContact_Click(object sender, EventArgs e)
        {
            string contactToAdd = "";
            if(uxLBContacts.SelectedIndex != -1)
            {
                contactToAdd = uxLBContacts.SelectedItem.ToString();
            }
            else if (uxLbOfflineContacts.SelectedIndex != -1)
            {
                contactToAdd = uxLbOfflineContacts.SelectedItem.ToString();
            }
            if (!ShowYesNoDialogBox(contactToAdd)) return;
            SendContactEventData evtData = new SendContactEventData(contactToAdd);
            Event evt = new Event(evtData, EventTypes.RemoveContactEvent);
            SendToServer(evt);
        }
        
        /// <summary>
        /// Safely signs out the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            //Send signout event to server and return to login window, where you can safely close program
            /*this.Close();
            Environment.Exit(0);*/
            Form_Closing(sender, null);
        }

        /// <summary>
        /// Requests a chatroom from the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartChat_Click(object sender, EventArgs e)
        {
            //ClientAccount contactToChat = uxLBContacts.SelectedItem as ClientAccount;
            if(uxLBContacts.SelectedIndex == -1)
            {
                MessageBox.Show("No contact selected. Please select an online contact!");
                return;
            }
            string contactName = uxLBContacts.SelectedItem.ToString();
            //Send friend name to server and start chat form

            //From https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            /*this.Hide();
            var chat = new ChatForm();
            chat.FormClosed += (s, args) => this.Close();
            chat.Show();*/
            JoinChatroomEventData evtData = new JoinChatroomEventData(contactName, -1);
            Event evt = new Event(evtData, EventTypes.CreateChatEvent);
            SendToServer(evt);
        }

        /// <summary>
        /// Receives an event from the server
        /// </summary>
        /// <param name="evt"></param>
        public void ReceiveFromServer(Event evt)
        {
            switch (evt.Type)
            {
                case EventTypes.ContactWentOnline:
                    SendContactEventData evtData = evt.GetData<SendContactEventData>();
                    string onlineContactUsername = evtData.Username;
                    //MessageBox.Show("Contact " + onlineContactUsername + " is now online.");
                    ClientAccount onlineContactAccount = Program.allContacts.Find(x => x.Username == onlineContactUsername);
                    onlineContactAccount.IsOnline = true;
                    if (this.InvokeRequired) this.Invoke(new Action(this.UpdateContactLB));
                    else this.UpdateContactLB();
                    break;

                case EventTypes.ContactWentOffline:
                    SendContactEventData offlineData = evt.GetData<SendContactEventData>();
                    string offlineContactUsername = offlineData.Username;
                    //MessageBox.Show("Contact " + offlineContactUsername + " is now offline");
                    ClientAccount offlineContactAccount = Program.allContacts.Find(x => x.Username == offlineContactUsername);
                    offlineContactAccount.IsOnline = false;
                    if (this.InvokeRequired) this.Invoke(new Action(this.UpdateContactLB));
                    else this.UpdateContactLB();
                    break;

                case EventTypes.SendAllContacts:
                    Program.allContacts.Clear();
                    SendAllContactsEventData sendContactEvtData = evt.GetData<SendAllContactsEventData>();
                    foreach (Tuple<bool, string> i in sendContactEvtData.AllContacts)
                    {
                        ClientAccount tempCAcc = new ClientAccount(i.Item2, i.Item1);
                        Program.allContacts.Add(tempCAcc);
                    }
                    if (this.InvokeRequired) this.Invoke(new Action(this.UpdateContactLB));
                    else this.UpdateContactLB();
                    break;

                case EventTypes.JoinedChatEvent:
                    JoinChatroomEventData joinChatEvtData = evt.GetData<JoinChatroomEventData>();
                    Program.tempChatID = joinChatEvtData.id;
                    Program.tempJoinedChatEvent = evt;
                    Program.clientState = Program.ClientStates.addChatroom;
                    if(!Program.openChatForms.Exists(r => r.ChatroomIndex == joinChatEvtData.id)) Program.SwitchForm(this);
                    
                    break;
            }
        }

        /// <summary>
        /// Requests a yes no answer from the user
        /// </summary>
        /// <returns></returns>
        public bool ShowYesNoDialogBox(string name)
        {
            //Use this for things like "PersonA wants to be a contact. Add them?"
            //or "PersonA wants you to join a chatroom. Join?"
            DialogResult dialogResult = MessageBox.Show("Do you want to remove '" +name+"' as a contact?" , "501 Chat", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }


        private void uxTxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Clears the addcontact textbox on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxTxtUsername_MouseUp(object sender, MouseEventArgs e)
        {
            uxTxtUsername.Text = "";
        }

        /// <summary>
        /// Safely logs out the user on any exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            LogoutEventData data = new LogoutEventData(Program.USERNAME);
            Event evt = new Event(data, EventTypes.LogoutEvent);
            Program.networkHandler.SendToServer(evt);
            Program.clientState = Program.ClientStates.exitProgram;
            MessageBox.Show("Thank you. You are now signed out.");
            Program.SwitchForm(this);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Sends an event to the server
        /// </summary>
        /// <param name="evt"></param>
        public void SendToServer(Event evt)
        {
            Program.networkHandler.SendToServer(evt);
        }

        /// <summary>
        /// Updates the contact list boxes with the correct contacts
        /// </summary>
        public void UpdateContactLB()
        {
            List<string> contactUsernames = new List<string>();
            List<string> offlineUsernames = new List<string>();
            foreach (ClientAccount contact in Program.allContacts)
            {
                if(contact.IsOnline)
                {
                    contactUsernames.Add(contact.Username);
                }
                else
                {
                    offlineUsernames.Add(contact.Username);
                }
            }

            


            uxLBContacts.DataSource = contactUsernames.ToList();
            uxLbOfflineContacts.DataSource = offlineUsernames.ToList();
            uxLBContacts.ClearSelected();//clear selected item
            uxLbOfflineContacts.ClearSelected();//clear selected item
            this.Invalidate();
            foreach(ChatForm form in Program.openChatForms)
            {
                form.UpdateContactLB();//Update all chatform Contact listboxes
            }
        }

        private void uxLBContacts_MouseClick(object sender, MouseEventArgs e)
        {
            uxLbOfflineContacts.ClearSelected();
        }

        private void uxLbOfflineContacts_MouseClick(object sender, MouseEventArgs e)
        {
            uxLBContacts.ClearSelected();
        }

        private void uxLBContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(uxLBContacts.SelectedIndex != -1)
            {
                uxLbOfflineContacts.ClearSelected();
            }
               
        }

        private void uxLbOfflineContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(uxLbOfflineContacts.SelectedIndex != -1)
            {
                uxLBContacts.ClearSelected();
            }
        }
    }
}
