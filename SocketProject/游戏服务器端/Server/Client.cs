using System.Net.Sockets;
using System;
namespace GameServer.Server
{
    class Client
    {
        private Socket clientSocket;
        private Server server;
        private Byte[] buffer = new Byte[1024];
        private Message message = new Message();
        public Client() { }
        public Client(Socket clientSocket,Server server) {
            this.clientSocket = clientSocket;
            this.server = server;
        }

        public void Start() {
            clientSocket.BeginReceive(message.Data, message.BeginIndex, message.EndIndex, SocketFlags.None, ReceiveCallBack, clientSocket);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                int count = clientSocket.EndReceive(ar);
                    if (count == 0) {
                        Close();
                    }
                message.ReadMessage(count);
                Start();
            }
            catch (Exception e) {
                Console.Write(e);
                Close();
            }
        }


        private void Close() {
            if (clientSocket != null) {
                clientSocket.Close();
                server.RemoveClient(this);
            }
            
        }
    }
}
