using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.ClientHost
{
    public class SenderMouseData : ISender
    {
        private UdpUtil util;

        private ISendable sendable;

        private int status;

        public SenderMouseData(UdpUtil util)
        {
           this.util = util;
        }

        public void Send()
        {
           if(sendable!=null)
            {
                byte[] infobyte = new byte[10];
                for(int k = 0; k < infobyte.Length; k++)
                {
                    infobyte[k] = 1;
                }
                util.Send(infobyte);
                byte[] bytes = sendable.Encode();
                byte[] temp = new byte[10];
                for(int i = 0; i < bytes.Length; i++)
                {
                    for(int j = 0; j < temp.Length; j++)
                    {
                        temp[j] = bytes[i];
                    }
                    util.Send(temp);
                }
                sendable = null;
            }
            else
            {
                byte[] noInfoByte = new byte[10];
                util.Send(noInfoByte);
            }
            util.Receive();
        }

        public void Send(ISendable data)
        {
            sendable = data;
        }

    }
}
