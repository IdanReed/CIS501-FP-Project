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
using FP_Core.Extensions;
using FP_Server.Models;
using FP_Core;

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
                        uxServerLogBox.AppendTextFormatted("SUCCESS! ", FontStyle.Bold, Color.Green)
                                      .AppendTextFormatted(message, FontStyle.Regular, Color.Black)
                                      .EndLine();
                        break;
                    }
                case LoggerMessageTypes.Error:
                    {
                        uxServerLogBox.AppendTextFormatted("ERROR! ", FontStyle.Bold, Color.Red)
                                      .AppendTextFormatted(message, FontStyle.Regular, Color.Black)
                                      .EndLine();
                        break;
                    }
                case LoggerMessageTypes.UserJoined:
                    {
                        uxServerLogBox.AppendTextFormatted(message, FontStyle.Bold, Color.Blue)
                                      .AppendTextFormatted(" has come online", FontStyle.Regular, Color.Black)
                                      .EndLine();
                        break;
                    }
                default:
                    {
                        if (!uxServerLogBox.IsDisposed)
                        {
                            uxServerLogBox.AppendText(message + "\n");
                        }
               
                        break;
                    }
            }
        }
        List<Account> accountList = null;
        List<ChatRoom> roomsList = null;
        public void Update(List<Account> accountListIn, List<ChatRoom> roomsListIn)
        {
            Action a = new Action(() =>
            {
                //userInfoUpdate();
                userListUpdate();
                chatRoomUpdate();
            });
            accountList = accountListIn;
            roomsList = roomsListIn;

            if (InvokeRequired)
            {
                Invoke(a);
            }
            else
            {
                a();
            }
        }

        ServerController controller = null;
        #region viewUpdate
        public void userListUpdate()
        {         
            uxUsersListbox.DataSource = accountList.ToList();
        }
        public void chatRoomUpdate()
        {
            StringBuilder roomBuilder = new StringBuilder();
            if (roomsList != null) { 
                foreach (ChatRoom room in roomsList)
                {
                    StringBuilder participants = new StringBuilder();
                    foreach (Account part in room.Participants)
                    {
                        participants.Append(part.Username + "\n");
                    }
                    roomBuilder.Append(
                        "Room ID: " + room.RoomID + "\n" +
                        "Participants: \n" + participants.ToString() + "\n\n"

                    );

                }
            }
            uxChatroomBox.Text = roomBuilder.ToString();
        }
        #endregion viewUpdate

        private void userInfoUpdate(object sender, EventArgs e)
        {
            Account selectedAccount = (Account)uxUsersListbox.SelectedItem;
            if (selectedAccount != null)
            {
                //StringBuilder userInfo = new StringBuilder();
                string isOnline = "no";
                if (selectedAccount.IsOnline)
                {
                    isOnline = "yes";
                }
                StringBuilder userInfo = new StringBuilder();
                userInfo.Append(
                    "User Name: " + selectedAccount.Username + "\n" +
                    "Password: " + selectedAccount.Password + "\n" +
                    "Is online: " + isOnline + "\n" +
                    "Contacts: " + "\n"
                );

                foreach(IAccount contact in selectedAccount.Contacts)
                {
                    userInfo.Append("\tUser: " + contact.Username + " - Online: " + contact.IsOnline + "\n" );
                }

                uxUserInfoBox.Text = userInfo.ToString();
            }
            else
            {
                uxUserInfoBox.Text = "";
            }
        }
    }

}
