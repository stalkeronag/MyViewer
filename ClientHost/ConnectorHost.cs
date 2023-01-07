using System;
using System.Net;
using System.Net.Sockets;
using MyViewer.Core;

namespace MyViewer.ClientHost
{
    public class ConnectorHost : Connector
    {
        private UdpUtil udpUtil;

        public ConnectorHost(IPEndPoint endPoint) : base(endPoint)
        {
            udpUtil = new UdpUtil(endPoint, new UdpClient(35000));
        }

        public override IReader GetReader()
        {
            return new ReaderImage(udpUtil);
        }

        public override ISender GetSender()
        {
            return new SenderKeys(udpUtil);
        }

        public override IUdpClient GetUdpClient()
        {
            return udpUtil;
        }
    }
}
