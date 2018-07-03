using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TCP服务器端
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("TCP服务端启动");

            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.31.105"), 88));
            
            socket.Listen(10);
            Socket cliectSocket = socket.Accept();
            string send = "你好";
            Byte[] dataBuffer = Encoding.UTF8.GetBytes(send);
            cliectSocket.Send(dataBuffer);


            Byte[] receiveDate = new Byte[1024];
            int count = cliectSocket.Receive(receiveDate);
            string receive = Encoding.UTF8.GetString(receiveDate, 0, count);
            Console.WriteLine(receive);
            
            cliectSocket.Close();
            socket.Close();

        }
    }
}
