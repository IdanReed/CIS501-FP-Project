using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class CreateAccountEventData: IEventData
    {
        public readonly string Username;
        public readonly string Password;

        public CreateAccountEventData(string u, string p)
        {
            Username = u;
            Password = p;
        }
    }
}
