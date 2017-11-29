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
        
        public ServerTestForm()
        {
            InitializeComponent();


            WebSocket ws = new WebSocket("ws://127.0.0.1:8001/chatApp");
            ws.OnMessage += MessageRecieved;
            ws.Connect();
        }

        private void MessageRecieved(object sender, EventArgs e)
        {

        }

        private void uxCreateAccountButton_Click(object sender, EventArgs e)
        {

        }
    }
}
