using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyViewer.Core;

namespace MyViewer.ClientHost
{
    public class ClientHost : IClient
    {
        private IPEndPoint endPoint;
        public ClientHost(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
        }

        public IConnector Connect()
        {
            return new ConnectorHost(endPoint);
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
