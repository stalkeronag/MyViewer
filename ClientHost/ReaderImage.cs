using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using MyViewer.Core;

namespace MyViewer.ClientHost
{
    public class ReaderImage : IReader
    {
        private UdpClient client;

        private IPEndPoint endPoint;

        public event Action<IReadable> OnImageReady;

        public ReaderImage(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
            client = new UdpClient(35000);
        }

        public IReadable Read()
        {
            ImageData image =  new ImageData();
            if(client.Available == 0)
            {
                return null;
            }
            byte[] data = GetData();
            
            image.DecodeObject = image.Decode(data);
            //OnImageReady.Invoke(image);
            return image;
        }

        public  byte[] GetData()
        {
           MemoryStream stream = new MemoryStream();
           byte[] countByte =  client.Receive(ref endPoint);
           int count = countByte[0];
           for(int i = 0; i < count; i++)
            {
                byte[] bytes = client.Receive(ref endPoint);
                stream.Write(bytes, 0, bytes.Length);
            }
            stream.Close();
            byte[] data = stream.ToArray();
            return data;
        }
    }
}
