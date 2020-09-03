using System;
using TCPLib;

namespace PlainClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Start();
            Console.ReadKey();
        }
    }
}
