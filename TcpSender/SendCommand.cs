using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpSender
{
    class SendCommand : ICommand
    {
        private string _Message;

        public SendCommand()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            _Message = new String(Enumerable.Repeat(chars, 50).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public SendCommand(string message)
        {
            _Message = message;
        }

        public void Execute(Client client)
        {
            lock (client)
            {
                client.Send(Encoding.GetEncoding(1251).GetBytes(_Message));
                Thread.Sleep(10000);
                client.Stop();
            }
        }

    }
}
