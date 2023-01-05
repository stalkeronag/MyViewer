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
        private UdpUtil util;

        public event Action<IReadable> OnImageReady;
        public ReaderImage(UdpUtil util)
        {
            this.util = util;
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
            MemoryStream stream = new MemoryStream();
            for (int i = 0; i < 10; i++)
            {
                byte[] bytes = util.Receive();
                stream.Write(bytes, 0, bytes.Length);
            }
            byte[] data = stream.ToArray();
            stream.Close();
            byte[] mes = Encoding.UTF8.GetBytes("вам сообщение пришло хихихиха");
            util.Send(mes);
            return data;
        }
    }
}
