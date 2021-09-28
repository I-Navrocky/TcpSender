using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpSender
{
    class SendBytesCommand : ICommand
    {
        private byte[] _Message;

        public SendBytesCommand()
        {
            _Message = new byte[]
                {
                    0x24, // 0 протокол 
                    54, 00, 00, 00, // 1..4 длина с заголовком
                    92, 224, 13, 00, // номер
                    00, // тип сообщения
                    106, // порядковый номер
                    32, 35, 36, 37, 33, 33, 35, // пароль
                    35, 216, 45, 68, // время
                    18, 00, 83, 215, // latitude
                    227, 47, 14, 138, // longitude
                    26, 15, 247, 246, // входы с 1 по 8
                    
                    233, 222, 45, 68, 18, 180, 80, 215,
                    227, 230, 14, 138, 26, 15, 247, 246,
                    226, 227, 45, 68, 18, 70, 126, 215,
                    227, 208, 15, 138, 26, 15, 247, 246,
                    60, 229, 45, 68, 98, 15, 89, 00,
                    00, 81, 157, 158, 25, 15, 247,
                    246, 185,

                    19 // контрольная сумма
                };
        }

        public void Execute(Client client)
        {
            lock (client)
            {
                client.Send(_Message);
                Thread.Sleep(10000);
                client.Stop();
            }
        }
    }
}
