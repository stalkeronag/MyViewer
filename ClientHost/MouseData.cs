using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyViewer.ClientHost
{
    public class MouseData : ISendable, IReadable
    {
        private MouseButtons buttons;

        private float dx;

        private float dy;
        public MouseData(float dx, float dy, MouseButtons button)
        {
            this.dx = dx;
            this.dy = dy;
            this.buttons = button;
        }

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
            byte[] bytes = new byte[100];
            bytes[0] = (byte)dx;
            bytes[1] = (byte)dy;
            return null;
        }
    }
}
