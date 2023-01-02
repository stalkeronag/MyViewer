using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Text;
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
            byte[] data = GetData();
            image.DecodeObject = image.Decode(data);
            //OnImageReady.Invoke(image);
            return image;
        }

        public  byte[] GetData()
        {
           MemoryStream stream = new MemoryStream();
           for(int i = 0; i < 10; i++)
            {
                byte[] bytes = client.Receive(ref endPoint);
                stream.Write(bytes, 0, bytes.Length);
            }
            stream.Close();
            byte[] data = stream.ToArray();
            byte[] mes = Encoding.UTF8.GetBytes("вам сообщение пришло хихихиха");
            client.Send(mes, mes.Length, endPoint);
            return data;
        }
    }
}
