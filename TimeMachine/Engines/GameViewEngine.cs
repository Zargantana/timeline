using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeMachine.DB;

namespace TimeMachine
{
    public abstract class GameViewEngine: IDisposable
    {        
        private bool _stop;

        protected FrameMultiBuffer FrameBuffer;
        protected FrameDBReader frameDBReader;
        protected string PlayerUID;
        protected string _world;

        public GameViewEngine(FrameMultiBuffer frameBuffer)
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

        protected abstract void GameTick();

        public virtual void Dispose()
        {
            frameDBReader.Dispose();
        }
    }
}
