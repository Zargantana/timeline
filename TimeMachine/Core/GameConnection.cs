using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SharedModels;

namespace TimeMachine
{
    public class GameConnection: IDisposable
    {
        private Thread GameViewEngineThread;
        private Thread PlayerInfoEngineThread;
        private FrameMultiBuffer FrameBuffer = new FrameMultiBuffer();
        private TMInformationMultiBuffer InformationBuffer = new TMInformationMultiBuffer();
        private GameViewEngine GameViewEngine;
        private PlayerInfoEngine PlayerInformationEngine;
        private KeysConnector keysConnector = new KeysConnector();
        private string PlayerUID { get; set; }        

        public GameConnection(string player, string world, PersonajesImages delegateFunc) 
        {
            PlayerUID = player;
            GameViewEngine = new TimeViewEngine(player, world, FrameBuffer, delegateFunc);
            GameViewEngineThread = new Thread(new ThreadStart(GameViewEngine.Start));
            GameViewEngineThread.Start();

            PlayerInformationEngine = new PlayerInfoEngine(player, world, InformationBuffer);
            PlayerInfoEngineThread = new Thread(new ThreadStart(PlayerInformationEngine.Start));
            PlayerInfoEngineThread.Start();
        }

        public string GetPalyerFrame()
        {
            try
            {
                return FrameBuffer.readLast()._buffer;
            }
            catch
            {
                return "";
            }
        }

        public TMInformation GetPalyerInformation()
        {
            try
            {
                return InformationBuffer.readLast();
            }
            catch
            {
                return null;
            }
        }

        public void EnqueueKeys(KeysPressed keys)
        {
            try
            {
                //Use remoting with WCF to the GameEngine
                keysConnector.EnqueueKeys(PlayerUID, keys);
            }
            catch
            { }
        }

        public void Dispose()
        {
            GameViewEngine.Stop();
            if (!GameViewEngineThread.Join(100))
            {
                try
                {
                    GameViewEngineThread.Abort();
                }
                catch { }
            }
            GameViewEngineThread = null;
            GameViewEngine.Dispose();

            PlayerInformationEngine.Stop();
            if (!PlayerInfoEngineThread.Join(100))
            {
                try
                {
                    PlayerInfoEngineThread.Abort();
                }
                catch { }
            }
            PlayerInfoEngineThread = null;
            PlayerInformationEngine.Dispose();

        }
    }
}
