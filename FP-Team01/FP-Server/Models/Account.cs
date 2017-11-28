using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Server.Models
{
    class Account
    {
        private List<Account> _contacts;
        private bool _isOnline;
        private string _userName;
        private string _password;

        public Account(string username, string password)
        {
            _userName = username;
            _password = password;
        }
        public List<Account> Contacts
        {
            get { return _contacts; }
        }

        public bool IsOnline
        {
            get { return _isOnline; }
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
