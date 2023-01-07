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
        private ISendable sendable;

        private UdpUtil util;

        public SenderKeys(UdpUtil util)
        {
            this.util = util;
        }


        public void Send(ISendable data)
        {
            sendable = data;
        }

        public void Send()
        {
            if (sendable != null)
            {
                byte[] temp = new byte[100];
                byte[] bytes = sendable.Encode();
                temp[0] = bytes[0];
                temp[1] = bytes[1];
                util.Send(temp);
                util.Receive();
                sendable = null;
            }
            else
            {
                byte[] temp = new byte[10];
                for (int i = 0; i < 10; i++)
                {
                    temp[i] = 5;
                }
                util.Send(temp);
                util.Receive();
            }
        }
    }
}
