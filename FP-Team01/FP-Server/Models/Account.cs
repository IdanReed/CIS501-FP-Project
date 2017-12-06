using FP_Core;
using FP_Server.Controller;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Server.Models
{
    public class Account : IAccount
    {
        private List<IAccount> _contacts;

        [JsonIgnore]
        private bool _isOnline;
        private string _userName;
        private string _password;

        [JsonIgnore]
        private ServerSocketBehavior _socket;

        [JsonIgnore]
        public ServerSocketBehavior Socket
        {
            get { return _socket; }
            set { _socket = value; }
        }

        [JsonConstructor]
        private Account() {  }
        public Account(string username, string password)
        {
            _userName = username;
            _password = password;
            _contacts = new List<IAccount>();
        }
        [JsonIgnore]
        public List<IAccount> Contacts
        {
            get { return _contacts; }
        }

        [JsonIgnore]
        public bool IsOnline
        {
            get { return _isOnline; }
            set { _isOnline = value;}
        }
        [JsonIgnore]
        public string Username
        {
            get { return _userName; }
        }
        [JsonIgnore]
        public string Password
        {
            get { return _password; }
        }
        public override string ToString()
        {
            return _userName ;
        }
    }
}
