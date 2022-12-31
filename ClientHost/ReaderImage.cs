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
            client = new UdpClient(0);
        }

        public IReadable Read()
        {
            ImageData image =  new ImageData();
            byte[] data = GetData();
            image.DecodeObject = image.Decode(data);
            OnImageReady.Invoke(image);
            return image;
        }

        public  byte[] GetData()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream targetStream = new MemoryStream();
                for(int i = 0; i < 10; i++)
                {
                    
                    byte[] bytes = client.Receive(ref endPoint);
                    stream.Write(bytes, 0, bytes.Length);
                }
                using(var decompressor = new GZipStream(stream,CompressionMode.Decompress))
                {
                    decompressor.CopyTo(targetStream);
                }
                byte[] data = targetStream.ToArray();
                stream.Close();
                targetStream.Close();
                return data;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new byte[512];
        }
    }
}
