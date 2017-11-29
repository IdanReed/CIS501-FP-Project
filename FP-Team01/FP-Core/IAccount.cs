using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_Core
{
    public interface IAccount
    {
        List<IAccount> Contacts { get; }
        string Username { get; }

        bool IsOnline { get; }
    }
}
