using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class LeaveChatroomEventData
    {
        string Username;
        int chatroom_id;

        public LeaveChatroomEventData(string name, int id)
        {
            Username = name;
            chatroom_id = id;
        }
    }
}
