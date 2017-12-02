using FP_Core;
using FP_Server.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Server.Models
{
    class Account : IAccount
    {
        private List<IAccount> _contacts;
        private bool _isOnline;
        private string _userName;
        private string _password;
        private ServerSocketBehavior _socket;

        public ServerSocketBehavior Socket
        {
            get { return _socket; }
            set { _socket = value; }
        }

        public Account(string username, string password)
        {
            _userName = username;
            _password = password;
            _contacts = new List<IAccount>();
        }
        public List<IAccount> Contacts
        {
            get { return _contacts; }
        }

        public List<IAccount> OnlineContacts
        {
            get { return _contacts.FindAll(a => a.IsOnline); }
        }

        public bool IsOnline
        {
            get { return _isOnline; }
            set { _isOnline = value;}
        }

        public string Username
        {
            get { return _userName; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
