using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachine
{
    public class Animations
    {
        private bool _stop;

        protected FrameMultiBuffer FrameBuffer;
 
        public Animations(FrameMultiBuffer frameBuffer)
        {
            FrameBuffer = frameBuffer;
        }

        public void Stop()
        {
            _stop = true;
        }

        public void Start()
        {
            _stop = false;
            while (!_stop)//Wanted: 40ms
            {
                GameTick(); // +19,82ms
                System.Threading.Thread.Sleep(21); // +21ms
            }
        }

        protected void GameTick()
        {
            FrameBuf _local = new FrameBuf();
            byte[] FileContents = System.IO.File.ReadAllBytes(SelectFile());
            //byte[] FileContents = System.IO.File.ReadAllBytes(SelectFileAnimation1());
            _local._buffer = System.Convert.ToBase64String(FileContents);
            FrameBuffer.writeNew(_local);
            GC.Collect();
        }

        private string SelectFile()
        {
            return ((DateTime.Now.Minute % 2) == 0) ? SelectFile3() : SelectFile2();
        }

        private string SelectFile2()
        {
            DateTime Momentum = DateTime.Now;
            int Milli = (int)Math.Floor((double)Momentum.Millisecond / 29.41f);
            int Sec = Momentum.Second % 6;

            int Number = (Sec * 34 + Milli) + 1;

            return "D:\\Olles\\TimeLine\\TimeLine\\Animation2\\Partida" + Number.ToString().PadLeft(5, '0') + ".jpg";
        }

        private string SelectFile3()
        {
            DateTime Momentum = DateTime.Now;
            int Milli = (int)Math.Floor((double)Momentum.Millisecond / 31.25f);
            int Sec = Momentum.Second % 20;

            int Number = (Sec * 32 + Milli) + 1;

            return "D:\\Olles\\TimeLine\\TimeLine\\Animation3\\Partida" + Number.ToString().PadLeft(5, '0') + ".jpg";
        }


    }
}
