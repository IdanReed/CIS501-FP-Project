using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core.Events
{
    public class ServerResponseEventData
    {
        public readonly string ErrorMessage;
        public readonly bool WasSuccessful;
        
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
