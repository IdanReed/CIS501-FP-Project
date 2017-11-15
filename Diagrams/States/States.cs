using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    public class States
    {
        public enum ClientStates
        {
            idle, inChatroom, notLoggedIn, createAccount
        };

        public enum ServerStates
        {
            idle, createChatroom, removeChatroom, handleLogin, handleAddAccount, handleAddContact, sendData, receiveData
        };
    }
}
