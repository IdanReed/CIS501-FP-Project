using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class LogoutEventData
    {
        public string Username;

        public LogoutEventData(string u)
        {
            Username = u;
        }
    }
}
