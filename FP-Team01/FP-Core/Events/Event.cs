using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public enum EventTypes
    {
        CreateAccountEvent,
        LoginLogoutEvent, //Might want to make these 2 separate events so we don't have to send password on logout
        CreateChatEvent,
        LeaveChatEvent,
        SendMessageEvent,
        AddContactEvent,
        RemoveContactEvent,
        ServerResponse,
    }
    public class Event
    {
        public EventTypes Type { get; set; }
        public object Data { get; set; }

        public Event(object data, EventTypes type)
        {
            Data = data;
            Type = type;
        }

        public T GetData<T>()
        {
            return ((JObject)Data).ToObject<T>();
        }
    }

}
