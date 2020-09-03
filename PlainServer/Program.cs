using System;
using TCPLib;

namespace PlainServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
            Console.ReadKey();
        }
    }
}
