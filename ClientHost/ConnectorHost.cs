using System;
using System.Net;
using System.Net.Sockets;
using MyViewer.Core;

namespace MyViewer.ClientHost
{
    public class ConnectorHost : Connector
    {

        public ConnectorHost(IPEndPoint endPoint) : base(endPoint)
        {

        }

        public override IReader GetReader()
        {
            return new ReaderImage(endPoint);
        }

        public override ISender GetSender()
        {
            return new SenderKeys(endPoint);
        }
    }
}
