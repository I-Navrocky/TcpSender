using System;
using System.Linq;
using System.Text;

namespace TcpSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var client = new Client("localhost", 8080);
            Console.WriteLine("Input command");
            var command = Console.ReadLine();
            CommandBuilder.Build(command).ForEach(c => c.Execute(client));
            Console.ReadKey();
        }
    }
}
