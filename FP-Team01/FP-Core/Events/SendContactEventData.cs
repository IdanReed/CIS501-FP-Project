using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    class SendContactEventData
    {
        string Username;
        
        public SendContactEventData(string name)
        {
            Username = name;
            
        }
        public override string ToString()
        {
            return Username;
        }

       

    }
}
