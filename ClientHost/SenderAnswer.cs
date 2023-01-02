using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.ClientHost
{
    public class SenderAnswer : ISender
    {
        private UdpClient client;

        private IPEndPoint endPoint;

        private int port;

        public SenderAnswer(IPEndPoint endPoint, int port)
        {
            this.endPoint = endPoint;
            endPoint.Port = 305;
            this.port = port;
            client = new UdpClient(port);    
        }

        public void Send(ISendable data)
        {
          byte[] bytes = data.Encode();
          client.Send(bytes, bytes.Length, endPoint);
        }
    }
}
