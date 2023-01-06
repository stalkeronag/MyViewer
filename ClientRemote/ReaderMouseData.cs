using MyViewer.ClientHost;
using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyViewer.ClientRemote
{
    public class ReaderMouseData : IReader
    {
        public UdpUtil util;

        public event Action<int,int,MouseKeys> OnMouseLeft;

        public event Action<int, int, MouseKeys> OnMouseRight;

        public event Action<int, int, MouseKeys> OnMouseMiddle;

        public ReaderMouseData(UdpUtil util)
        {
            this.util = util;
        }


        public IReadable Read()
        {
            byte[] temp = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                temp[i] = util.Receive()[0];
            }
            float dx = BitConverter.ToSingle(temp, 0);
            int X = (int)(Screen.PrimaryScreen.Bounds.Width*dx);
            for (int i = 0; i < 4; i++)
            {
                temp[i] = util.Receive()[0];
            }
            float dy = BitConverter.ToSingle(temp, 0);
            int Y = (int)(Screen.PrimaryScreen.Bounds.Height * dx);
            byte[] clickData = util.Receive();
            int code = clickData[0];
            MouseKeys key;
            switch (code)
            {
                case 0:
                    key = MouseKeys.left;
                    OnMouseLeft.Invoke(X, Y, key);
                    break;
                case 1:
                    key = MouseKeys.right;
                    OnMouseLeft.Invoke(X, Y, key);
                    break;
                case 2:
                    key = MouseKeys.middle;
                    OnMouseMiddle.Invoke(X, Y, key);
                    break;
            }
            byte[] mes = Encoding.UTF8.GetBytes("вам сообщение пришло хихихиха");
            util.Send(mes);
            return null;
        }
    }
}
