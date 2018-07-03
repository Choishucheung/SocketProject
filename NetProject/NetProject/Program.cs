using System;
using System.Net.Sockets;
using System.Net;

namespace sendSocket
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
            serverSocket.Listen(10);
            Socket clientSocket =  serverSocket.Accept();
            string send = "Hellow你好";
            Byte[] B_send = System.Text.Encoding.UTF8.GetBytes(send);
            clientSocket.Send(B_send);


            Byte[] dataBuffer = new Byte[1024];
            int count = clientSocket.Receive(dataBuffer);
            string msg = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine(msg);

            clientSocket.Close();
            serverSocket.Close();
        }
    }
}
