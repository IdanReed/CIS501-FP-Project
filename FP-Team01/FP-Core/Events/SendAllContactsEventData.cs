using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class SendAllContactsEventData
    {
        private List<Tuple<bool,string>> _allContacts;
        private string _username;

        public SendAllContactsEventData(string u)
        {
            _username = u;
        }

        public List<Tuple<bool,string>> AllContacts
        {
            get
            {
                return _allContacts;
            }
            set
            {
                _allContacts = value;
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
