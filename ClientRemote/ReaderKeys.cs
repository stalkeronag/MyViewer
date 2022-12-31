using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using MyViewer.Core;

namespace MyViewer.ClientRemote
{
    public class ReaderKeys : IReader
    {
        private IPEndPoint endPoint;

        private UdpClient client;

        public ReaderKeys(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
            client = new UdpClient(0);
            
        }

        public IReadable Read()
        {
            byte[] bytes =  client.Receive(ref endPoint);
            int code = bytes[0];
            //this is wrong
            return null;
            //Input data depends on code
        }
    }
}
