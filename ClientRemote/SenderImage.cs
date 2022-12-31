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
        private IPEndPoint endPoint;

        private UdpClient client;

        public SenderImage(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
            client = new UdpClient();
        }

        public void Send(ISendable data)
        {
            byte[] bytes = data.Encode();
            SendPartitions(bytes);
        }

        public void SendPartitions(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            MemoryStream targetStream = new MemoryStream();
            using(var compressor = new GZipStream(targetStream,CompressionMode.Compress,true))
            {
                stream.CopyTo(compressor);
            }
            int length = (int)targetStream.Length;
            int lengthPartitions = length / 10;
            for (int i = 0; i < 10; i++)
            {
                byte[] temp = new byte[lengthPartitions];
                targetStream.Read(temp, 0, temp.Length);
                client.Send(temp, temp.Length, endPoint);
            }
        }
    }
}
