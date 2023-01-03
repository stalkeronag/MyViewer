using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.ClientHost
{
    public class BlockIOHost : BlockIO
    {
        public BlockIOHost(IReader reader, ISender sender) : base(reader, sender)
        {

        }

        public override void Read()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    base.Read();
                }
            });
        }

        public override void Send()
        {
            base.Send();
        }
    }
}
