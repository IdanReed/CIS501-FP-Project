using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Server.Models
{
    public class ChatRoom
    {
        private int _roomID;
        private List<Account> _participants;

        public ChatRoom(int roomID)
        {
            _roomID = roomID;
            _participants = new List<Account>();
        }

        public int RoomID
        {
            get { return _roomID; }
        }
        public List<Account> Participants
        {
            get { return _participants; }
        }
    }
}
