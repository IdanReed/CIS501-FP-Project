using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace FP_Team01
{
    static class Program
    {
        public enum ClientStates
        {
            Idle, inChatroom, notLoggedIn, createAccount, exitProgram,
        }
        public static string USERNAME = ""; //use these to pass between the GUIs 
        public static string PASSWORD = ""; //might not need this beyond the login screen, but we'll see what happens
        public static NetworkHandler networkHandler;
        public static ClientStates clientState;
        public static Form formToClose;
        public static Form formToOpen;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clientState = ClientStates.Idle;
            networkHandler = new NetworkHandler();
            Application.Run(new LoginForm());     
        }//Wow this is a cool comment
        //man Jarod you right. This is a cool comment.

        public static void SwitchForm(Form ToClose)
        {
            formToClose = ToClose;

            switch (clientState)
            {
                case ClientStates.inChatroom:
                    formToClose.Hide();
                    formToOpen = new ChatForm();
                    formToOpen.FormClosed += (s, args) => formToClose.Dispose();
                    formToOpen.Show();
                    break;
                case ClientStates.notLoggedIn:
                    formToClose.Hide();
                    formToOpen = new LoginForm();
                    formToOpen.FormClosed += (s, args) => formToClose.Dispose();
                    formToOpen.Show();
                    break;
                case ClientStates.Idle:
                    formToClose.Hide();
                    formToOpen = new MainMenu();
                    formToOpen.FormClosed += (s, args) => formToClose.Dispose();
                    formToOpen.Show();
                    break;
                case ClientStates.exitProgram:
                    Environment.Exit(0);
                    break;
            }
            //this.Hide();
            //var mainMenu = new MainMenu();
            //mainMenu.FormClosed += (s, args) => this.Close();
            //mainMenu.Show();
        }
    }
}
