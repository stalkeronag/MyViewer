using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyViewer.ClientHost
{
    public class ControllerHost : Controller
    {
        private bool IsActive;
        public ControllerHost(IClient client, Form1 form) : base(client,form)
        {
            Form.OnKeyDownPress += sender.Send;
            Form.OnKeyUpPress += sender.Send;
        }

        public override void Start()
        {
            IsActive = true;
            base.Start();
            Task.Run(() =>
            {
                while (IsActive)
                {
                    reader.Read();
                    sender.Send();
                }
            });
             
        }

        public override void Stop()
        {
            base.Stop();
            IsActive = false;
            Form.OnKeyDownPress -= sender.Send;
            Form.OnKeyUpPress -= sender.Send;
        }
    }
}
