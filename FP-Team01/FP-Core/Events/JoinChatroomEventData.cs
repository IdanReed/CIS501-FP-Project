using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class JoinChatroomEventData
    {
        string Username;
        public JoinChatroomEventData(string name)
        {
            Username = name;
        }
    }
}
