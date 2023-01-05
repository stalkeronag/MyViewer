using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.ClientHost
{
    public class KeysData : IReadable, ISendable
    {
        private int codeKey;

        public object DecodeObject { get; set; }

        public KeysData(int code)
        {
            codeKey = code;
        }
        
        public string ConverToString(byte[] data)
        {
            throw new NotImplementedException();
        }

        public object Decode(byte[] bytes)
        {
           throw new NotImplementedException();
        }

        public byte[] Encode()
        {
            byte[] bytes = new byte[2];
            if(codeKey > 255)
            {
                bytes[0] = 1;
                bytes[1] = (byte)(codeKey - 255);
            }
            else
            {
                bytes[0] = 0;
                bytes[1] = (byte)codeKey;
            }
            return bytes;
        }
    }
}
