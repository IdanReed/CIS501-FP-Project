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
    public partial class MainMenu : Form
    {
        string Username;
        public MainMenu()
        {
            Username = Program.USERNAME;
            InitializeComponent();
            uxLabelName.Text = "Welcome, " + Username + ".";
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

        }
    }
}
