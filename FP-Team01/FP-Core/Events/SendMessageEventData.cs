using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class SendMessageEventData
    {
        public string Username;
        public string Message;
        public DateTime Time;
        public int ChatRoomIndex;

        public SendMessageEventData(string name, string msg, DateTime msgTime, int index)
        {
            Username = name;
            Message = msg;
            Time = msgTime;
            ChatRoomIndex = index;
        }

    }
}
