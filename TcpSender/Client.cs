using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpSender
{
    class Client
    {
        private string _Host;
        private int _Port;
        private TcpClient _TcpClient;
        private Thread _Thread;

        public Client(string host, int port)
        {
            _Host = host;
            _Port = port;
            _TcpClient = new TcpClient();
        }

        public void Send(byte[] data)
        {
            _Thread = new Thread(new ParameterizedThreadStart(SendingRoutine));
            _Thread.Start(data);
        }

        public void Stop()
        {
            _Thread = null;
        }

        private void SendingRoutine(object param)
        {
            try
            {
                var data = param as byte[];
                _TcpClient.Connect(_Host, _Port);
                NetworkStream stream = _TcpClient.GetStream();
                stream.Write(data, 0, data.Length);

                while (_Thread != null)
                {
                    Thread.Sleep(1000);
                }

                _TcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
