using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.Core
{
    public interface ISender
    {
         void Send();

         void Send(ISendable data);
    }
}
