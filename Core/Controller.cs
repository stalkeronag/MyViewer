using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyViewer.Core
{
    public class Controller
    {
        protected Form1 form;

        protected IClient client;

        protected IConnector connector;

        protected ISender sender;

        protected IReader reader;

        protected IReadableHandler handler;

        protected List<IReader> additionReader;

        protected List<ISender> additionSender;

        public Form1 Form
        {
            get
            {
                return form;
            }
            set
            {
                form = value;
            }
        }

        public IClient Client
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
            }
        }

        public IConnector Connector
        {
            get
            {
                return connector;
            }
            set
            {
                connector = value;
            }
        }

        public ISender Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }

        public IReader Reader
        {
            get
            {
                return reader;
            }
            set
            {
                reader = value;
            }
        }

        public IReadableHandler Handler
        {
            get
            {
                return handler;
            }
            set
            {
                handler = value;
            }
        }
        public Controller(IClient client, Form1 form)
        {
            this.client = client;
            this.form = form;
            Connector = client.Connect();
            Reader = Connector.GetReader();
            Sender = Connector.GetSender();
            Form.StopAction += Stop;
            Form.StartAction += Start;
            additionReader = new List<IReader>();
            additionSender= new List<ISender>();
        }

        public virtual void Start()
        {
            Form.StartAction -= Start;
        }

        public virtual void Stop()
        {
            Form.StopAction -= Stop;

        }

        public void AddReader(IReader reader)
        {
            additionReader.Add(reader);
        }

        public void AddSender(ISender sender)
        {
            additionSender.Add(sender);
        }
    }
}
