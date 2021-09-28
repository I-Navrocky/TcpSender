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

            while (true)
            {
                var command = Console.ReadLine();

                if (command.Equals("q"))
                    break;

                CommandBuilder.Build(command).ForEach(c => c.Execute(client));

            }

            Console.WriteLine("End");
        }
    }
}
