using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyViewer.Core;

namespace MyViewer.ClientHost
{
    public class SenderKeys : ISender
    {
        private IPEndPoint endPoint;

        private UdpClient client;

        public SenderKeys(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
            client = new UdpClient(0);
        }

        public void Send(ISendable data)
        {
            throw new NotImplementedException();
        }
    }
}
