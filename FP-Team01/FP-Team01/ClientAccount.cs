using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP_Core;

namespace FP_Team01
{
    class ClientAccount : FP_Core.IAccount
    {
        private List<IAccount> _contacts;
        private List<IAccount> _onlineContacts;
        private string _username;
        private bool _isOnline = true;

        public List<IAccount> Contacts
        {
            get
            {
                return _contacts;
            }
        }

        public bool IsOnline
        {
            get
            {
                return _isOnline;
            }
        }

        public List<IAccount> OnlineContacts
        {
            get
            {
                return _onlineContacts;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
        }
    }
}
