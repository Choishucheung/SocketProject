using System.Net.Sockets;
using System;
namespace GameServer.Server
{
    class Client
    {
        private Socket clientSocket;
        private Server server;
        private Byte[] buffer = new Byte[1024];
        public Client() { }
        public Client(Socket clientSocket,Server server) {
            this.clientSocket = clientSocket;
            this.server = server;
        }

        public void Start() {
            clientSocket.BeginReceive(buffer,0,1024,SocketFlags.None,ReceiveCallBack,clientSocket);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                int count = clientSocket.EndReceive(ar);
                    if (count == 0) {
                        Close();
                    }
                clientSocket.BeginReceive(buffer, 0, 1024, SocketFlags.None, ReceiveCallBack, clientSocket);

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
