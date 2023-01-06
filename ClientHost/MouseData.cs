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


        private float dx;

        private float dy;
        public MouseData(float dx, float dy, MouseButtons button)
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
            float[] arr = new float[2];
            arr[0] = dx;
            arr[1] = dy;
            byte[] tempDx = BitConverter.GetBytes(arr[0]);
            byte[] tempDy = BitConverter.GetBytes(arr[1]);
            byte[] bytes = new byte[9];
            for(int i = 0; i < 8; i++)
            {
                if(i > 3)
                {
                    bytes[i] = tempDy[i - 4];
                }
                else
                {
                    bytes[i] = tempDx[i];
                }
            }
            bytes[8] = (byte)key;
            return bytes; 
        }
    }
}
