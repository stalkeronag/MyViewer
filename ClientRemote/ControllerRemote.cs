using MyViewer.ClientHost;
using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyViewer.ClientRemote
{
    public class ControllerRemote : Controller
    {
        private bool IsActive = false;

        public ControllerRemote(IClient client, Form1 form) : base(client,form)
        {
            Handler = new Emulator((ReaderKeys)Reader);
        }

        public override void Start()
        {
            IsActive = true;
            base.Start();
            Task.Run(() =>
            {
                while (IsActive)
                {
                    sender.Send(new ImageData());
                    reader.Read();
                }
            });
           
        }

        public override void Stop()
        {
            base.Stop();
            IsActive = false;
        }
    }
}
