using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace FP_Team01
{
    static class Program
    {
        public enum ClientStates
        {
            Idle, inChatroom, notLoggedIn, createAccount, exitProgram, addChatroom, removeChatroom, openMainMenu
        }
        public static string USERNAME = ""; //use these to pass between the GUIs 
        public static string PASSWORD = ""; //might not need this beyond the login screen, but we'll see what happens
        public static NetworkHandler networkHandler;
        public static ClientStates clientState;
        public static Form formToClose;
        public static Form formToOpen;
        public static List<ChatForm> openChatForms;
        public static List<ClientAccount> allContacts;
        public static int tempChatID;
        public static bool mainFormOpen;
        //public static string serverIP;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            openChatForms = new List<ChatForm>();
            allContacts = new List<ClientAccount>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainFormOpen = false;

            clientState = ClientStates.notLoggedIn;
            Application.Run(new LoginForm());
        }//Wow this is a cool comment
        //man Jarod you right. This is a cool comment.

        public static void SwitchForm(Form ToClose)
        {
            formToClose = null;
            formToOpen = null;
            formToClose = ToClose;

            switch (clientState)
            {
                case ClientStates.inChatroom:
                    /*if (formToClose.InvokeRequired) formToClose.Invoke(new Action(formToClose.Hide));
                    else formToClose.Hide();
                    formToOpen = new ChatForm();
                    formToOpen.FormClosed += (s, args) => formToClose.Dispose();
                    formToOpen.ShowDialog();*/
                    break;
                case ClientStates.notLoggedIn:
                    if (formToClose.InvokeRequired) formToClose.Invoke(new Action(formToClose.Hide));
                    else formToClose.Hide();
                    formToOpen = new LoginForm();
                    formToOpen.FormClosed += (s, args) => formToClose.Dispose();
                    formToOpen.Show();
                    clientState = ClientStates.Idle;
                    break;
                case ClientStates.openMainMenu:
                    if (!mainFormOpen)
                    {
                        if (formToClose.InvokeRequired) formToClose.Invoke(new Action(formToClose.Hide));
                        else formToClose.Hide();
                        formToOpen = new MainMenu();
                        formToOpen.FormClosed += (s, args) => formToClose.Dispose();
                        formToClose.Invoke(new Action(formToOpen.Show));
                        //formToOpen.Show();//.ShowDialog();
                        clientState = ClientStates.Idle;
                        mainFormOpen = true;
                    }
                    break;
                case ClientStates.addChatroom:
                    formToOpen = new ChatForm();
                    openChatForms.Add(formToOpen as ChatForm);
                    ChatForm tempForm = formToOpen as ChatForm;
                    tempForm.ChatroomIndex = tempChatID;
                    //f
                    clientState = ClientStates.Idle;
                    break;
                case ClientStates.removeChatroom:
                    formToClose.Hide();
                    openChatForms.Remove(formToClose as ChatForm);
                    formToClose.Dispose();
                    clientState = ClientStates.Idle;
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

        public static void CreateNetwork(string IP)
        {
            networkHandler = new NetworkHandler(IP);
        }
    }
}
