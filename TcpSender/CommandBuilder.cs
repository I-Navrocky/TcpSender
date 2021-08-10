using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpSender
{
    static class CommandBuilder
    {
        public static List<ICommand> Build(string inputStr)
        {
            var res = new List<ICommand>();
            List<string> commList = inputStr.Split(" ").ToList();

            foreach (string comm in commList)
            {
                if (comm.Equals("send"))
                    res.Add(new SendCommand());                
            }

            return res;
        }
    }
}
