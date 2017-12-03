using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class LeaveChatroomEventData
    {
        public string Username;
        public LeaveChatroomEventData(string name)
        {
            Username = name;
        }
    }
}
