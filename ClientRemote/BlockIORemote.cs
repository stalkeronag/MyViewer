using MyViewer.ClientHost;
using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.ClientRemote
{
    public class BlockIORemote : BlockIO
    {
        public BlockIORemote(IReader reader, ISender sender) : base(reader, sender)
        {

        }

        public override void Read()
        {
            Task.Run(() =>
            {
                while(true)
                {
                    reader.Read();
                }
            });
        }

        public override void Send()
        {
            Task.Run(() =>
            {
                while(true)
                {
                    sender.Send(new ImageData());
                }
            });
        }
    }
}
