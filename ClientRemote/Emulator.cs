using MyViewer.ClientHost;
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
    [Flags]
    public enum MouseEventFlags
    {
        LEFTDOWN = 0x00000002,
        LEFTUP = 0x00000004,
        MIDDLEDOWN = 0x00000020,
        MIDDLEUP = 0x00000040,
        MOVE = 0x00000001,
        ABSOLUTE = 0x00008000,
        RIGHTDOWN = 0x00000008,
        RIGHTUP = 0x00000010
    }

    public class Emulator : IReadableHandler
    {
        private ReaderKeys reader;

        private ReaderMouseData readerMouseData;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;

        public Emulator(ReaderKeys reader, ReaderMouseData readerMouse)
        {
            this.reader = reader;
            this.reader.OnKeyCodeUp += KeyUp;
            this.reader.OnKeyCodeDown += KeyDown;
            readerMouseData = readerMouse;
            readerMouseData.OnMouseLeft += MouseLeft;
            readerMouseData.OnMouseRight += MouseRight;
            readerMouseData.OnMouseMiddle += MouseMiddle;
        }

        public void MouseLeft(int X, int Y, MouseKeys key)
        {
            mouse_event((uint)MouseEventFlags.LEFTDOWN, (uint)X, (uint)Y, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTUP, (uint)X, (uint)Y, 0, 0);
        }

        public void MouseRight(int X, int Y, MouseKeys key)
        {
            mouse_event((uint)MouseEventFlags.RIGHTDOWN, (uint)X, (uint)Y, 0, 0);
            mouse_event((uint)MouseEventFlags.RIGHTUP, (uint)X, (uint)Y, 0, 0);
        }

        public void MouseMiddle(int X, int Y, MouseKeys key)
        {
            mouse_event((uint)MouseEventFlags.MIDDLEDOWN, (uint)X, (uint)Y, 0, 0);
            mouse_event((uint)MouseEventFlags.MIDDLEUP, (uint)X, (uint)Y, 0, 0);
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
