using MyViewer.Core;
using System;
using System.Text;

namespace MyViewer.ClientHost
{
    public class TextData : IReadable, ISendable
    {
        public object DecodeObject { get; set; }

        public TextData(string str)
        {
            DecodeObject = str;
        }

        public string ConverToString(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        public object Decode(byte[] bytes)
        {
            string result = Encoding.UTF8.GetString(bytes);
            DecodeObject = result;
            return result;
        }

        public byte[] Encode()
        {
            byte[] bytes = Encoding.UTF8.GetBytes((string) DecodeObject);
            return bytes;
        }
    }
}
