using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class LoginLogoutEventData
    {
        public readonly string Username;
        public readonly string Password;
        public readonly EventTypes createEvent;

        public LoginLogoutEventData(string u, string p)
        {
            Username = u;
            Password = p;
            createEvent = EventTypes.LoginLogoutEvent;
        }
    }
}
