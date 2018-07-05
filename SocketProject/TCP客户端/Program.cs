using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

namespace TCP客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.31.105"), 90));
            Byte[] dataBuffer = new Byte[1024];
            int count = clientSocket.Receive(dataBuffer);
            string msg = Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.Write(msg);

            while (true) {
                string s = Console.ReadLine();
                if (s == "c") {
                    clientSocket.Close();
                    return;
                }
                Byte[] sendmsg = Encoding.UTF8.GetBytes(s);
                clientSocket.Send(sendmsg);
             }
            Console.ReadKey();
            clientSocket.Close();
        }

        
    }
}
