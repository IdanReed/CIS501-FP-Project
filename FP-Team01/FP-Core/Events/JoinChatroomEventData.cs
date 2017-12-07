using Newtonsoft.Json;
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
        public List<SendMessageEventData> messageLog;

        [JsonConstructor]
        private JoinChatroomEventData() { }
        public JoinChatroomEventData(string name, int chatroomID)
        {
            Username = name;
            id = chatroomID;
        }
        public JoinChatroomEventData(string name, int chatroomID, List<SendMessageEventData> msgLog)
        {
            Username = name;
            id = chatroomID;
            messageLog = msgLog;
        }
    }
}
