﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace GameServer.Server
{
    class Server
    {

        private IPEndPoint ipEndPoint;
        private Socket serverSocket;
        private List<Client> clientList;

        public Server() {

        }

        public Server(string ipStr, int port) {
            setIPEndPoint(ipStr, port);
        }

        public void setIPEndPoint(string ipStr, int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipStr), port);
        }

        public void Start() {
            serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AccpetCallBack, serverSocket);
        }

        private void AccpetCallBack(IAsyncResult ar) {
            Socket clientSocket = serverSocket.EndAccept(ar);
            Client client = new Client(clientSocket,this);
            clientList.Add(client);
            client.Start();
        }

        public void RemoveClient(Client client) {
            lock (clientList) {
                clientList.Remove(client);
            }
        }

    }
}
