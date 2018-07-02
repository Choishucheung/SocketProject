using System;
using System.Net.Sockets;
using System.Net;

namespace NetProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 88);
            serverSocket.Bind(iPEndPoint);//绑定ip和端口号 申请
            Console.WriteLine("Hello World!");
        }
    }
}
