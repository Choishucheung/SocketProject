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
            StartServerAsync();
            Console.ReadKey();
        }


        static void StartServerAsync()
        {
            Console.Write("TCP服务端启动");

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.31.105"), 90));

            socket.Listen(10);

            socket.BeginAccept(AcceptCallBack,socket);
            //Socket cliectSocket = socket.Accept();
            //string send = "你好";
            //Byte[] dataBuffer = Encoding.UTF8.GetBytes(send);
            //cliectSocket.Send(dataBuffer);


            //Byte[] receiveDate = new Byte[1024];
            //int count = cliectSocket.Receive(receiveDate);
            //string receive = Encoding.UTF8.GetString(receiveDate, 0, count);
            //Console.WriteLine(receive);

            //Console.ReadKey();
            //cliectSocket.Close();
            //socket.Close();

            //Data = new Byte[1024];
            //cliectSocket.BeginReceive(Data, 0, 1024, SocketFlags.None, ReceiveCallBack, cliectSocket);

        }

        private static void AcceptCallBack(IAsyncResult ar)
        {
            Socket acceptSocket = ar.AsyncState as Socket;
            Socket cliectSocket = acceptSocket.EndAccept(ar);
            string send = "你好";
            Byte[] dataBuffer = Encoding.UTF8.GetBytes(send);
            cliectSocket.Send(dataBuffer);
            //Data = new Byte[1024];
            cliectSocket.BeginReceive(msg.Data, msg.BeginCount, msg.EndCount, SocketFlags.None, ReceiveCallBack, cliectSocket);
            acceptSocket.BeginAccept(AcceptCallBack, acceptSocket);
        }
        static Message msg = new Message();
        static Byte[] Data = new Byte[1024];


       

        static void ReceiveCallBack(IAsyncResult ar) {
            Socket CallBackSocket = ar.AsyncState as Socket;//System.Net.Sockets.SocketException
            try
            {
                int count = CallBackSocket.EndReceive(ar);
                if (count == 0) {
                    if (CallBackSocket != null)
                    {
                        CallBackSocket.Close();
                    }
                    return;
                }
                msg.addCount(count);
                msg.ReadMessage();

                //Console.WriteLine("从客户端接受到的数据" + Encoding.UTF8.GetString(Data, 0, count));
                //CallBackSocket.BeginReceive(Data, 0, 1024, SocketFlags.None, ReceiveCallBack, CallBackSocket);
                CallBackSocket.BeginReceive(msg.Data, msg.BeginCount, msg.EndCount, SocketFlags.None, ReceiveCallBack, CallBackSocket);
            }
            catch(SocketException)
            {
                if (CallBackSocket != null)
                {
                    CallBackSocket.Close();
                }
                
            }
            finally {

            }
           
        }

    }
}
