using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyViewer.ClientHost;
using MyViewer.Core;

namespace MyViewer.ClientRemote
{
    public class SenderImage : ISender
    {
        private UdpUtil util;

        public SenderImage(UdpUtil util)
        {
            this.util = util;
        }

        public void Send(ISendable data)
        {
            byte[] bytes = data.Encode();
            SendPartitions(bytes);
        }

        public void Send()
        {
            throw new NotImplementedException();
        }

        public void Send(int id)
        {
            throw new NotImplementedException();
        }

        public void SendPartitions(byte[] bytes)
        {
           
            MemoryStream stream = new MemoryStream(bytes);
            int length = bytes.Length;
            int countPartiotions = 10;
            int lengthPartitions = length / countPartiotions;
            byte[] temp = new byte[lengthPartitions];
            for (int i = 0;  i < countPartiotions - 1; i++)
            {
                stream.Read(temp, 0, lengthPartitions);
                util.Send(temp);
            }
            lengthPartitions = lengthPartitions + length % countPartiotions;
            byte[] last = new byte[lengthPartitions];
            stream.Read(last, 0, lengthPartitions);
            util.Send(last);
            util.Receive();

        }
    }
}
