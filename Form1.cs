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
        public event Action StopAction;

        public event Action StartAction;

        public event Action<ISendable> OnKeyDownPress;

        public event Action<ISendable> OnKeyUpPress;

        public event Action<ISendable> OnMousePress;

        public Form1()
        {
            InitializeComponent();

        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            float dx = (float)e.X / (float)pictureBox1.Width;
            float dy = (float)e.Y / (float)pictureBox1.Height;
            MouseButtons button = e.Button;
            OnMousePress.Invoke(new MouseData(dx, dy, button));
        }

        private void RemoteMode(object senderr, EventArgs e)
        {

        }



        private void Draw()
        {

        }

        private void Port_TextChanged(object sender, EventArgs e)
        {

        }

        private void KeyDownPress(object sender, KeyEventArgs e)
        {
            int code = e.KeyValue;
            OnKeyDownPress.Invoke(new KeysData(code));
        }

        private void KeyUpRealease(object sender, KeyEventArgs e)
        {

            int code = e.KeyValue;
            code = code + 255;
            OnKeyUpPress.Invoke(new KeysData(code));
        }

        private void HostMode(object sender, MouseEventArgs e)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpEndPoint.Text), 0);
            IClient client = new ClientHost.ClientHost(endPoint);
            Controller controllerHost = new ControllerHost(client, this);
            controllerHost.Handler = new Televisor(pictureBox1, (ReaderImage)controllerHost.Reader);
        }

        private void RemoteMode(object sender, MouseEventArgs e)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpEndPoint.Text), 35000);
                IClient client = new ClientRemote.ClientRemote(endPoint);
                Controller controllerRemote = new ControllerRemote(client, this);
            }
            catch (Exception ex)
            {

            }
        }

        private void Stop(object sender, MouseEventArgs e)
        {
            StopAction.Invoke();
        }

        private void Start(object sender, MouseEventArgs e)
        {
            try
            {
                if (StartAction != null)
                    StartAction.Invoke();
                button4.Enabled = false;
                KeyDown += KeyDownPress;
                KeyUp += KeyUpRealease;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
