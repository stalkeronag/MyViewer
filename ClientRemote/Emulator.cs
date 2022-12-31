using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyViewer.ClientRemote
{
    public class Emulator : IReadableHandler
    {
        private IReader reader;
        public Emulator(IReader reader)
        {
            this.reader = reader;
        }

        public void Start()
        {
            while(true)
            {
                IReadable readable =reader.Read();
                Handle(readable);
            }
        }

        public void Handle(IReadable readable)
        {
            throw new NotImplementedException();
        }
    }
}
