using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpSender
{
    interface ICommand
    {
        void Execute(Client client);
    }
}
