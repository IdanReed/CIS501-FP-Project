using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class JoinChatroomEventData
    {
        public string Username;
        public int id;

        public JoinChatroomEventData(string name, int chatroomID)
        {
            Username = name;
            id = chatroomID;
        }
    }
}
