using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP_Core;

namespace FP_Team01
{
    class ClientAccount : IAccount
    {
        private List<IAccount> _contacts;
        private string _username;
        private bool _isOnline = true;

        public ClientAccount(string u)
        {
            _username = u;
            _contacts = new List<IAccount>();
        }

        public List<IAccount> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
            }
        }

        public bool IsOnline
        {
            get
            {
                return _isOnline;
            }
            set
            {
                _isOnline = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
    }
}
