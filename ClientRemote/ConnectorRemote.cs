using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyViewer.Core;

namespace MyViewer.ClientRemote
{
    public class ConnectorRemote : Connector
    {
        public ConnectorRemote(IPEndPoint endPoint) : base(endPoint)
        {
        }

        public override IReader GetReader()
        {
            return new ReaderKeys(endPoint);
        }

        public override ISender GetSender()
        {
            return new SenderImage(endPoint);
        }
    }
}
