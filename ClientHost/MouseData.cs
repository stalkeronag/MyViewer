using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyViewer.ClientHost
{
    public enum MouseKeys : int
    {
        left = 0,
        right = 1,
        middle = 2
    }

    public class MouseData : ISendable, IReadable
    {
        private MouseKeys key;


        private ushort dx;

        private ushort dy;

        public MouseData(ushort  dx, ushort dy, MouseButtons button)
        {
            this.dx = dx;
            this.dy = dy;
            switch (button)
            {
                case MouseButtons.Left:
                    key = MouseKeys.left;
                    break;
                case MouseButtons.Right:
                    key = MouseKeys.right;
                    break;
                case MouseButtons.Middle:
                    key = MouseKeys.middle;
                    break;
            }

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
            ushort[] arr = new ushort[2];
            arr[0] = dx;
            arr[1] = dy;
            byte[] tempDx = BitConverter.GetBytes(arr[0]);
            byte[] tempDy = BitConverter.GetBytes(arr[1]);
            byte[] bytes = new byte[5];
            bytes[0] = tempDx[0];
            bytes[1] = tempDx[1];
            bytes[2] = tempDy[0];
            bytes[3] = tempDy[1];
            bytes[4] = (byte)key;
            return bytes; 
        }
    }
}
