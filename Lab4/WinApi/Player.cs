using System;
using System.Text;
using System.Runtime.InteropServices;

namespace WinApi
{
    public class Player
    {
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public Player()
        {
        }

        private bool paused;

        private int volume = 50;
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                int t = value;
                if (value < 0)
                {
                    t = 0;
                }
                if (value > 100)
                {
                    t = 100;
                }
                volume = t;
                t *= 10;
                mciSendString("setaudio MediaFile volume to " + t.ToString(), null, 0, IntPtr.Zero);
            }
        }
        
        private void Close()
        {
            mciSendString("close MediaFile", null, 0, IntPtr.Zero);
        }

        public bool Play(string file)
        {
            Close();
            if (!mciSendString("open \"" + file + "\" alias MediaFile", null, 0, IntPtr.Zero).Equals(0))
            {
                return false;
            }
            if (!mciSendString("play MediaFile", null, 0, IntPtr.Zero).Equals(0))
            {
                Close();
                return false;
            }
            Volume = Volume;
            paused = false;
            return true;
        }

        public void Pause()
        {
            mciSendString((paused ? "resume" : "pause") + " MediaFile", null, 0, IntPtr.Zero);
            paused = !paused;
        }

        public void Stop()
        {
            mciSendString("stop MediaFile", null, 0, IntPtr.Zero);
            Close();
        }

        public int GetTiming()
        {
            var ms = new StringBuilder(128);
            mciSendString("status MediaFile position", ms, 128, IntPtr.Zero);
            return int.Parse(ms.ToString());
        }

        public void SetTiming(int ms)
        {
            if (ms < 0)
            {
                ms = 0;
            }
            mciSendString("play MediaFile from " + ms.ToString(), null, 0, IntPtr.Zero);
            if (paused)
            {
                paused = false;
                Pause();
            }
        }
    }
}
