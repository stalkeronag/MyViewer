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

        private IReader readerMouse;

        private IReader readerKeybd;

        public ControllerRemote(IClient client, Form1 form) : base(client,form)
        {
            readerMouse = connector.GetReaders()[1];
            readerKeybd = connector.GetReaders()[0];
            Handler = new Emulator((ReaderKeys)readerKeybd, (ReaderMouseData)readerMouse);
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
                    readerKeybd.Read();
                    readerMouse.Read();
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
