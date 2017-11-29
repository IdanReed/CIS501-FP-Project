using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class LoginLogoutEventData
    {
        public string Username;
        public string Password;
        public EventTypes createEvent;

        public LoginLogoutEventData(string u, string p)
        {
            Username = u;
            Password = p;
            createEvent = EventTypes.LoginLogoutEvent;
        }
    }
}
