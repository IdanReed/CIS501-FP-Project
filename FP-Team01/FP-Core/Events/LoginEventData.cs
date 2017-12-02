using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class LoginEventData
    {
        public string Username;
        public string Password;

        public LoginEventData(string u, string p)
        {
            Username = u;
            Password = p;
        }
    }
}
