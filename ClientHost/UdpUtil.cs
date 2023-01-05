using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.ClientHost
{
    public class UdpUtil
    {
        private UdpClient client;

        private IPEndPoint endPoint;

        public UdpUtil(IPEndPoint endPoint, UdpClient client)
        {
            this.endPoint = endPoint;
            this.client = client;
        }

        public void Send(byte[] data)
        {
            client.Send(data, data.Length, endPoint);
        }

        public byte[] Receive()
        {
            return client.Receive(ref endPoint);
        }
    }
}
