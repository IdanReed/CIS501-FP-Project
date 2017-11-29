using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_Team01
{
    public partial class ChatForm : Form
    {
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
    }
}
