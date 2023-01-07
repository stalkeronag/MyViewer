using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyViewer.ClientHost;
using MyViewer.Core;

namespace MyViewer.ClientRemote
{
    public class ConnectorRemote : Connector
    {
        private UdpUtil util;

        public ConnectorRemote(IPEndPoint endPoint) : base(endPoint)
        {
            util = new UdpUtil(endPoint,new UdpClient());

        }

        public override IReader GetReader()
        {
            
            return new ReaderKeys(util);
        }

        public override ISender GetSender()
        {
            return new SenderImage(util);
        }

        public override IUdpClient GetUdpClient()
        {
            return util;
        }
    }
}
