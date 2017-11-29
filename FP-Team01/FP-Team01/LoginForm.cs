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
    public partial class LoginForm : Form
    {
        string Username;
        string Password;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnCreateAcct_Click(object sender, EventArgs e)
        {
            Username = uxTBUsername.Text;
            Password = uxTBPassword.Text;
            FP_Core.Events.CreateAccountEventData createEvent = new FP_Core.Events.CreateAccountEventData(Username, Password);
            //Send this to the server?
            bool wasSuccessful = true; //need to get this from the server
            if (wasSuccessful)
            {
                Program.USERNAME = Username;
                Program.PASSWORD = Password;
                //Open main menu GUI

                //From https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
                this.Hide();
                var mainMenu = new MainMenu();
                mainMenu.FormClosed += (s, args) => this.Close();
                mainMenu.Show();
                
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Username = uxTBUsername.Text;
            Password = uxTBPassword.Text;
            FP_Core.Events.LoginLogoutEventData loginEvent = new FP_Core.Events.LoginLogoutEventData(Username, Password);
            //Send this to the server?
            bool wasSuccessful = true; //need to get this from the server
            if (wasSuccessful)
            {
                Program.USERNAME = Username;
                Program.PASSWORD = Password;
                //Open main menu GUI
                Application.Run(new MainMenu());
            }
        }
    }
}
