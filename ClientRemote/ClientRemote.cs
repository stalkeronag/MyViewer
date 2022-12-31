using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyViewer.Core;

namespace MyViewer.ClientRemote
{
    public class ClientRemote : IClient
    {
        private IPEndPoint endPoint;

        public ClientRemote(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
        }

        public IConnector Connect()
        {
            return new ConnectorRemote(endPoint);
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
