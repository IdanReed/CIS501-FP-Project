using FP_Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace ServerTester
{
    public partial class ServerTestForm : Form
    {

        private WebSocket _ws;
        public ServerTestForm()
        {
            InitializeComponent();


            _ws = new WebSocket("ws://127.0.0.1:8001/chatApp");
            _ws.OnMessage += MessageRecieved;
            _ws.Connect();
        }

        private void MessageRecieved(object sender, MessageEventArgs e)
        {
            Event evt = JsonConvert.DeserializeObject<Event>(e.Data);

            switch (evt.Type)
            {
                case EventTypes.ServerResponse:
                    {
                        ServerResponseEventData response = evt.GetData<ServerResponseEventData>();

                        if (!response.WasSuccessful)
                        {
                            MessageBox.Show(response.ErrorMessage);
                        }
                        break;
                    }
                case EventTypes.SendContact:
                    {
                        SendContactEventData data = evt.GetData<SendContactEventData>();

                        MessageBox.Show(data.Username + " has come online");

                        break;
                    }
                case EventTypes.ContactWentOffline:
                    {
                        SendContactEventData data = evt.GetData<SendContactEventData>();

                        MessageBox.Show(data.Username + " has gone offline");

                        break;
                    }
                case EventTypes.SendMessageEvent:
                    {
                        SendMessageEventData data = evt.GetData<SendMessageEventData>();

                        MessageBox.Show("You've recieved a message!");
                        MessageBox.Show(data.Message);

                        break;
                    }
            } 
        }

        private void uxCreateAccountButton_Click(object sender, EventArgs e)
        {
            string username = uxUsername.Text;
            string password = uxPassword.Text;

            CreateAccountEventData data = new CreateAccountEventData(username, password);

            Event evt = new Event(data, EventTypes.CreateAccountEvent);

            _ws.Send(JsonConvert.SerializeObject(evt)); 
        }

    

        private void uxLoginButton_Click(object sender, EventArgs e)
        {
            string username = uxUsername.Text;
            string password = uxPassword.Text;

            LoginEventData data = new LoginEventData(username, password);

            Event evt = new Event(data, EventTypes.LoginEvent);

            _ws.Send(JsonConvert.SerializeObject(evt)); 
        }

        private void uxAddContactButton_Click(object sender, EventArgs e)
        {
            string username = uxUsername.Text;

            SendContactEventData data = new SendContactEventData(username);

            Event evt = new Event(data, EventTypes.AddContactEvent);

            _ws.Send(JsonConvert.SerializeObject(evt));
        }

        private void uxLogoutButton_Click(object sender, EventArgs e)
        {
            string username = uxUsername.Text;

            LogoutEventData data = new LogoutEventData(username);

            Event evt = new Event(data, EventTypes.LogoutEvent);

            _ws.Send(JsonConvert.SerializeObject(evt));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JoinChatroomEventData data = new JoinChatroomEventData(uxUsername.Text, -1);

            Event evt = new Event(data, EventTypes.CreateChatEvent);

            _ws.Send(JsonConvert.SerializeObject(evt));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendMessageEventData data = new SendMessageEventData(uxUsername.Text, "MessageText", DateTime.Now, Convert.ToInt32(uxPassword.Text));

            Event evt = new Event(data, EventTypes.SendMessageEvent);

            _ws.Send(JsonConvert.SerializeObject(evt));
        }
    }
}
