using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.Core
{
    public class InputData : IReadable, ISendable
    {
        public object DecodeObject { get; set; }

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
            throw new NotImplementedException();
        }
    }
}
