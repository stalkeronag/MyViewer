using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using MyViewer.Core;
using MyViewer.ClientHost;
using System.Windows.Forms;

namespace MyViewer.ClientRemote
{
    public class ReaderKeys : IReader
    {
        private UdpUtil util;

        public event Action<Keys> OnKeyCodeUp;

        public event Action<Keys> OnKeyCodeDown;

        public ReaderKeys(UdpUtil util)
        {
            this.util = util;
        }

        public IReadable Read()
        {
            byte[] bytes = util.Receive();
            if (bytes[0] == 0)
            {
                OnKeyCodeDown.Invoke((Keys)bytes[1]);
            }
            else
            {
                if (bytes[0] == 1)
                {
                    OnKeyCodeUp.Invoke((Keys)bytes[1]);
                }
            }
            byte[] mes = Encoding.UTF8.GetBytes("вам сообщение пришло хихихиха");
            util.Send(mes);
            return new KeysData(600);
        }
    }
}
