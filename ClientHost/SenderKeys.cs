using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using MyViewer.Core;

namespace MyViewer.ClientHost
{
    public class SenderKeys : ISender
    {
        private List<ISendable> sendables;

        private UdpUtil util;

        public SenderKeys(UdpUtil util)
        {
            this.util = util;
            sendables = new List<ISendable>();
        }


        public void Send(ISendable data)
        {
            sendables.Add(data);
        }

        public void Send()
        {
           
            byte[] count = new byte[100];
            count[0] = (byte)sendables.Count;
            util.Send(count);
            if (sendables.Count > 0)
            {
                byte[] encodeSendable = new byte[2];
                foreach (var item in sendables)
                {
                    encodeSendable = item.Encode();
                    util.Send(encodeSendable);
                }
                sendables.Clear();
            }
            util.Receive();
        }
    }
}
