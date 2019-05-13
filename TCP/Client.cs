using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    class Client
    {
        
        public Client(int PORT_NO, string SERVER_IP){
            this.PORT_NO = PORT_NO;
            this.SERVER_IP = SERVER_IP;
            tcpClient = new TcpClient(SERVER_IP, PORT_NO);
            networkStream = tcpClient.GetStream();
        }

        public Client()
        {
            this.PORT_NO = 8080;
            this.SERVER_IP = "localhost";
            tcpClient = new TcpClient(this.SERVER_IP, this.PORT_NO);
            networkStream = tcpClient.GetStream();
        }

        #region Fields
        private int PORT_NO;
        private string SERVER_IP;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private string lastSent;
        private string lastReceived;
        #endregion

        #region Getters/Setters
        public string SERVER_IP1 { get => SERVER_IP; }
        public int PORT_NO1 { get => PORT_NO; }
        public string LastSent { get => lastSent; }
        #endregion

        #region Methods
        public void sendMsg(string message)
        {
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);
            lastSent = message;
            networkStream.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void receiveMsg()
        {
            byte[] bytesToRead = new byte[tcpClient.ReceiveBufferSize];
            int bytesRead = networkStream.Read(bytesToRead, 0, tcpClient.ReceiveBufferSize);
        }
        #endregion



    }
}

