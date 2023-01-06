using System;
using System.Net;
using System.Net.Sockets;
using MyViewer.Core;

namespace MyViewer.ClientHost
{
    public class ConnectorHost : Connector
    {
        private UdpUtil udpUtil;

        private int counter;

        public ConnectorHost(IPEndPoint endPoint) : base(endPoint)
        {
            counter = 0;
            udpUtil = new UdpUtil(endPoint, new UdpClient(35000));
        }

        public override IReader GetReader()
        {
            return new ReaderImage(udpUtil);
        }

        public override ISender GetSender()
        {
            return new SenderInputData(udpUtil);
        }
    }
}
