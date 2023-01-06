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
            status = 0;
        }

        public void Send(int id)
        {
           if(status != 0)
            {
                byte[] bytes = sendable.Encode();
                byte[] temp = new byte[5];
                for(int i = 0; i < bytes.Length; i++)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        temp[j] = bytes[i];
                    }
                    util.Send(temp);
                }
                util.Receive();
                status = 0;
            }
        }

        public void Send(ISendable data)
        {
            sendable = data;
            status = 1;
        }

    }
}
