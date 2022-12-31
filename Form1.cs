using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyViewer.Core;
using MyViewer.ClientHost;
using MyViewer.ClientRemote;
using System.Net;
using System.Runtime.ExceptionServices;

namespace MyViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
           
        }


        private void HostMode(object send, EventArgs e)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 0);
                IClient client = new ClientHost.ClientHost(endPoint);
                IConnector connector = client.Connect();
                IReader reader = connector.GetReader();
                //ISender sender = connector.GetSender();
                //EventsInput inputs = new EventsInput(sender);
                Task.Run(() =>
                {
                    while(true)
                    {
                       IReadable readable =  reader.Read();
                       pictureBox1.Image = (Bitmap)readable.DecodeObject;
                    }
                });
                //while(true)
                //{
                //    reader.Read();
                //}

            }
            catch(Exception ex)
            {
                richTextBox1.Text = ex.ToString();
            }
            
        }

        private void RemoteMode(object senderr, EventArgs e)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpEndPoint.Text), 0);
                IClient client = new ClientRemote.ClientRemote(endPoint);
                IConnector connector = client.Connect();
                /*IReader reader = connector.GetReader()*/;
                ISender sender = connector.GetSender();
                EventTimer timer = new EventTimer(sender);
                sender.Send(new ImageData());
                //IReadableHandler handler = new Emulator(reader);
                //Task.Run(handler.Start);
                
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.ToString();
            }
        }

        private void Disconnect(object sender, EventArgs e)
        {

        }

        private void Draw()
        {
            
        }

        private void Port_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
