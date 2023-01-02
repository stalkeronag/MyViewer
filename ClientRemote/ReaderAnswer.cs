using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyViewer.ClientHost;

namespace MyViewer.ClientRemote
{
    public class ReaderAnswer : IReader
    {
        private UdpClient client;

        private IPEndPoint endPoint;

        private int port;

        public ReaderAnswer(IPEndPoint endPoint, int port)
        {
            this.endPoint = endPoint;
            endPoint.Port = 201;
            this.port = port;
            client = new UdpClient(port);
        }

        public IReadable Read()
        {
            byte[] bytes = client.Receive(ref endPoint);
            return new TextData(Encoding.UTF8.GetString(bytes));
        }
    }
}
