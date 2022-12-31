using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Drawing.Imaging;

namespace MyViewer.ClientHost
{
    public class ImageData : ISendable, IReadable
    {
        private int width;

        private int height;

        public object DecodeObject { get; set; }

        public ImageData()
        {
            width = Screen.PrimaryScreen.Bounds.Width;
            height= Screen.PrimaryScreen.Bounds.Height;
        }

        public ImageData(byte[] bytes)
        {

        }

        public void ConverToString(byte[] data)
        {
            throw new NotImplementedException();
        }

        public object Decode(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            Bitmap bmp = (Bitmap)Bitmap.FromStream(stream);
            DecodeObject = bmp;
            return DecodeObject;
        }

        public byte[] Encode()
        {
            Bitmap background = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(background);
            graphics.CopyFromScreen(0, 0, 0, 0, new Size(width, height));
            MemoryStream stream = new MemoryStream();
            background.Save(stream, ImageFormat.Bmp);
            return stream.ToArray();
        }
    }
}
