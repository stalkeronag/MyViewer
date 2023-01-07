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

        public event Action<int, int> OnMouseLeft;

        public event Action<int, int> OnMouseRight;

        public event Action<int, int> OnMouseMiddle;

        public ReaderMouseData(UdpUtil util)
        {
            this.util = util;
        }


        public IReadable Read()
        {
            byte[] infoByte = util.Receive();
            if (infoByte[0] == 1)
            {
                byte[] temp = new byte[2];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = util.Receive()[0];
                }
                ushort dx = BitConverter.ToUInt16(temp,0);
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = util.Receive()[0];
                }
                ushort dy = BitConverter.ToUInt16(temp,0);
                byte[] clickData = util.Receive();
                int code = clickData[0];
                MouseKeys key;
                switch (code)
                {
                    case 0:
                        key = MouseKeys.left;
                        OnMouseLeft.Invoke(dx, dy);
                        break;
                    case 1:
                        key = MouseKeys.right;
                        OnMouseLeft.Invoke(dx, dy);
                        break;
                    case 2:
                        key = MouseKeys.middle;
                        OnMouseMiddle.Invoke(dx, dy);
                        break;
                }
            }
            byte[] mes = Encoding.UTF8.GetBytes("вам сообщение пришло хихихиха");
            util.Send(mes);
            return null;
        }
    }
}
