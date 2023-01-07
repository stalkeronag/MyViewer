using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.Core
{
    public enum Status
    {
        Connected,
        NonConnected
    }
    public interface IConnector
    {
        Status status{ get; set; }

        ISender GetSender();

        IReader GetReader();
    }
}
