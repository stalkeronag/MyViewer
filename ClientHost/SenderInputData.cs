using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.ClientHost
{
    public class SenderInputData:ISender
    {
        private UdpUtil util;

        private ISender senderMouseData;

        private ISender senderKeyData;

        public SenderInputData(UdpUtil util)
        {
            this.util = util;
            senderKeyData = new SenderKeys(util);
            senderMouseData = new SenderMouseData(util);
        }

        public void Send(int id)
        {
            if(id == 1)
            {
                senderMouseData.Send(0);
            }
            if(id == 0)
            {
                senderKeyData.Send(id);
            }
        }

        public void Send(ISendable sendable)
        {
            throw new NotImplementedException();
        }

    }
}
