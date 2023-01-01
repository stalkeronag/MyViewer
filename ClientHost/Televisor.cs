﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyViewer.Core;
using System.Windows.Forms;
using System.Drawing;
namespace MyViewer.ClientHost
{
    public class Televisor : IReadableHandler
    {
        private PictureBox box;

        private ReaderImage reader;

        public Televisor(PictureBox box)
        {
            this.box = box;
        }

        public Televisor(PictureBox box, ReaderImage reader)
        {
            this.box = box;
            this.reader = reader;
            reader.OnImageReady += Handle;
            box.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Handle(IReadable readable)
        {
            box.Image = (Bitmap)readable.DecodeObject;
            
            //box.Image = ResizeImage(bmp, box.Width, box.Height);
        }

        public Image ResizeImage(Bitmap bmp, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(bmp, 0, 0, width, height);
            return bitmap;
        }

        public void Start()
        {
            
        }
    }
}
