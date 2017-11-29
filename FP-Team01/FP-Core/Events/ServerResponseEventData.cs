using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class ServerResponseEventData
    {
        public string ErrorMessage;
        public bool WasSuccessful;
        
        public ServerResponseEventData(string errorMessage)
        {
            WasSuccessful = false;
            ErrorMessage = errorMessage;
        } 
        public ServerResponseEventData()
        {
            WasSuccessful = true;
        }
    }
}
