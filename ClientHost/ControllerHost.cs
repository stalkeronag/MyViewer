using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyViewer.ClientHost
{
    public class ControllerHost : Controller
    {
        private bool IsActive;
        public ControllerHost(IClient client, Form1 form) : base(client,form)
        {
           
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
