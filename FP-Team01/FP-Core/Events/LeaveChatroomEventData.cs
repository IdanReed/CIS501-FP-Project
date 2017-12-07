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
        public int ChatroomID;
        public LeaveChatroomEventData(string name, int id)
        {
            Username = name;
            ChatroomID = id;
        }
    }
}
