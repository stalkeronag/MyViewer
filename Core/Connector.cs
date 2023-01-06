using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.Core
{
    public class Connector : IConnector
    {

        public virtual Status status { get; set; }

        protected IPEndPoint endPoint;

        public Connector(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
        }

        public virtual IReader GetReader()
        {
            throw new NotImplementedException();
        }

        public virtual ISender GetSender()
        {
            throw new NotImplementedException();
        }

        public virtual IReader[] GetReaders()
        {
            throw new NotImplementedException();
        }
    }
}
