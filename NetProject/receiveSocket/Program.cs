using System;
using System.Net.Sockets;
using System.Net;

namespace receiveSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("10.65.85.44"),88));
            Byte[] dataBuffer = new Byte[1024];
            int count = clientSocket.Receive(dataBuffer);
            string msg = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.Write(msg);

            string s = Console.ReadLine();
            Byte[] sendmsg = System.Text.Encoding.UTF8.GetBytes(s);
            clientSocket.Send(sendmsg);

            clientSocket.Close();
        }
    }
}
