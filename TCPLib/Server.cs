using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;

namespace TCPLib
{
    public class Server
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 10001);
            server.Start();
            Console.WriteLine("Simple server is ready.");
            while (true)
            {
                TcpClient tempSocket = server.AcceptTcpClient();

                Task.Run(() => HandleClient(tempSocket));
            }
        }

        private void HandleClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            string receivedStr = sr.ReadLine();
            Console.WriteLine($"Received: {receivedStr}");
            Car car = DeserializeCar(receivedStr);
            if (car != null)
            {
                Console.WriteLine($"Deserialized car: {car}");
            }
            sw.WriteLine(receivedStr);
            sw.Flush();
            socket.Close();
        }

        private Car DeserializeCar(string serializedCar)
        {
            var carProperties = serializedCar.Split(", ");
            if (carProperties.Length < 3)
            {
                return null;
            }
            Car car = new Car(
                carProperties[0],
                carProperties[1],
                carProperties[2]);

            return car;
        }
    }
}
