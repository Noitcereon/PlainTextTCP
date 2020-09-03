using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using ModelLib;

namespace TCPLib
{
    public class Client
    {
        public void Start()
        {
            TcpClient socket = new TcpClient("127.0.0.1", 10001);

            DoClient(socket);
        }

        private void DoClient(TcpClient socket)
        {
            Car car = new Car("Berlingo", "Silver", "UZ624");

            NetworkStream ns = socket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            string output = car.ToString();
            sw.WriteLine(output);
            sw.Flush();

            string serverResponse = sr.ReadLine();
            Console.WriteLine(serverResponse);

            socket.Close();
        }
    }
}
