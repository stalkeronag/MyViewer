using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.Core
{
    public class BlockIO
    {
        protected IReader reader;

        protected ISender sender;

        public BlockIO(IReader reader, ISender sender)
        {
            this.reader = reader;
            this.sender = sender;
        }

        public virtual void Read()
        {
            reader.Read();
        }

        public virtual void Send()
        {
            throw new NotImplementedException();
        }
    }
}
