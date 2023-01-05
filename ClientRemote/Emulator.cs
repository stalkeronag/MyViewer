using MyViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyViewer.ClientRemote
{
    public class Emulator : IReadableHandler
    {
        private ReaderKeys reader;

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;

        public Emulator(ReaderKeys reader)
        {
            this.reader = reader;
            this.reader.OnKeyCodeUp += KeyUp;
            this.reader.OnKeyCodeDown += KeyDown;
        }

        public static void KeyDown(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        public static void KeyUp(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        public void Start()
        {
           
        }

        public void Handle(IReadable readable)
        {
            throw new NotImplementedException();
        }
    }
}
