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
            Idle, inChatroom, notLoggedIn, createAccount,
        }
        public static string USERNAME = ""; //use these to pass between the GUIs 
        public static string PASSWORD = ""; //might not need this beyond the login screen, but we'll see what happens
        public static NetworkHandler networkHandler;
        public static ClientStates clientState;
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
            switch (clientState)
            {
                case ClientStates.inChatroom:
                    Application.Run(new ChatForm());
                    break;
                case ClientStates.notLoggedIn:
                    Application.Run(new LoginForm());
                    break;
                case ClientStates.Idle:
                    Application.Run(new MainMenu());
                    break;
            }
        }//Wow this is a cool comment
    }
}
