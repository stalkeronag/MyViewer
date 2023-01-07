using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.Core
{
    public interface IUdpClient
    {
        void Send(byte[] data);

        byte[] Receive();

    }
}
