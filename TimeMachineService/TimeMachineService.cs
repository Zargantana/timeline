using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SharedModels;
using System.Threading;
using TimeMachine;

namespace TimeMachineService
{
    public class GameConnBundle
    {
        public ServiceHost serviceHostFrames;
        public ServiceHost serviceHostInformation;
        public ServiceHost serviceHostKeys;
        public GameConnection GConn;
    }


    /*
     * TODO: Necesitamos un watchdog de que si no pide frames ni envia keys en 20 segundos, desconecta.
     */
    public class TimeMachineGameService: IFramesTimeMachineGameService, IKeysTimeMachineGameService, ISelectWorldTimeMachineGameService, IInformationTimeMachineGameService
    {
        
        private static Dictionary<string, GameConnBundle> GameConnections = new Dictionary<string, GameConnBundle>();
        private static readonly PlayerImagesEngine PreloadedPlayersImages = new PlayerImagesEngine();
        private Thread PlayersImagesThread;

        /********  
         * IFramesTimeMachineGameService
        ********/
        public string GetPalyerFrame(string player)
        {
            if (GameConnections.ContainsKey(player)) return GameConnections[player].GConn.GetPalyerFrame();
            return "";
        }

        /********  
         * IKeysTimeMachineGameService
        ********/
        public void SetKeystrokes(string player, TMKeyStrokes keys)
        {
            //TODO: select the connection by player
            if (GameConnections.ContainsKey(player)) GameConnections[player].GConn.EnqueueKeys(ChangeStructures(keys));
        }

        /********  
         * IInformationTimeMachineGameService
        ********/
        public TMInformation GetPalyerInformation(string player)
        {
            if (GameConnections.ContainsKey(player)) return GameConnections[player].GConn.GetPalyerInformation();
            return new TMInformation();
        }

        /********  
         * ISelectWorldTimeMachineGameService
        ********/
        public void SelectOrCreateWorld(string player, string worldName)
        {
            if ((player == "") || (worldName == "")) return;

            GameConnBundle GCB;

            //TODO: Remove to start using logins or something
            if (GameConnections.ContainsKey(player))
            {
                GCB = GameConnections[player];
                GameConnections.Remove(player);

                GCB.serviceHostFrames.Close();
                GCB.serviceHostFrames = null;
                GCB.serviceHostInformation.Close();
                GCB.serviceHostInformation = null;
                GCB.serviceHostKeys.Close();
                GCB.serviceHostKeys = null;
                GameConnection _local = GCB.GConn;
                GCB.GConn = null;
                _local.Dispose();
                _local = null;
                GC.Collect();
            }

            GCB = new GameConnBundle();

            GCB.GConn = new GameConnection(player, worldName, PreloadedPlayersImages.PersonajesImages);
            //Can receive from REST API
            GCB.serviceHostFrames = StartFramesListener(player);
            GCB.serviceHostInformation = StartInformationListener(player);
            GCB.serviceHostKeys = StartKeysListener(player);

            GameConnections.Add(player, GCB);
        }

        private KeysPressed ChangeStructures(TMKeyStrokes Keys)
        {
            KeysPressed _result = new KeysPressed();

            _result.Key_P = Keys.Key_P;
            _result.Key_O = Keys.Key_O;
            _result.Key_Q = Keys.Key_Q;
            _result.Key_A = Keys.Key_A;
            _result.Key_W = Keys.Key_W;
            _result.Key_D = Keys.Key_D;
            _result.Key_S = Keys.Key_S;
            _result.Key_E = Keys.Key_E;
            _result.Key_SP = Keys.Key_SP;

            return _result;

        }

        /********  
         * ILogin
        ********/

        // FUTURISSIM TODO: GameConnection se conecta al mundo que desde otra api han levantado (supuestamente hace nada, el en html anterior)

        /********  
         * INewWorld
        ********/

        // FUTURISSIM TODO: GameConnection se conecta al mundo que desde otra api han levantado (supuestamente hace nada, el en html anterior)

        /********  
        * IConnect
        ********/
        /*
         * FUTURISSIM TODO: GameConnection se conecta al mundo que desde otra api han levantado (supuestamente hace nada, el en html anterior)
         * 
        public void NewConnection(string playerName, string World)
        {
            FrameMultiBuffer _local = new FrameMultiBuffer();
            Animations _GameConnection = new Animations(playerName, World, _local);
            _frameBufferDictionary.Add(playerName, _local);
            _connectionsBufferDictionary.Add("playerName", _GameConnection);
        }
        */

        /*******
         * ENGINE Start/Stop
        *******/
        public void Start()
        {
            StartWorldSelectListener();
            //TODO: maintain preloaded player images collection with a thread class to do it.
            
            PlayersImagesThread = new Thread(new ThreadStart(PreloadedPlayersImages.Start));
            PlayersImagesThread.Start();
        }

        public void Stop()
        {            
            foreach (KeyValuePair<string, GameConnBundle> gameConnBundle in GameConnections)
            {
                //gameConnBundle.Value.serviceHostFrames.Close(); Too Costly
                gameConnBundle.Value.serviceHostFrames = null;
                //gameConnBundle.Value.serviceHostKeys.Close(); Too Costly
                gameConnBundle.Value.serviceHostKeys = null;
                gameConnBundle.Value.GConn.Dispose();
                gameConnBundle.Value.GConn = null;
            }
            GameConnections.Clear();

            //Clear player images collection and stop the maintainer thread
            PreloadedPlayersImages.Stop();
            if (!PlayersImagesThread.Join(100))
            {
                try
                {
                    PlayersImagesThread.Abort();
                }
                catch { }
            }
            PlayersImagesThread = null;
            PreloadedPlayersImages.Dispose();

            GC.Collect();
        }

        //FRAMES COMMAND LISTENER
        private static ServiceHost StartFramesListener(string player)
        {
            TimeSpan ipcTimeout = new TimeSpan(0, 0, 1);           
            string ipcAddressFrames = "net.pipe://localhost/FramesTimeMachineIPC" + player;

            ServiceHost serviceHostFrames = new ServiceHost(typeof(TimeMachineGameService));
            NetNamedPipeBinding bindingFrmaes = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            bindingFrmaes.SendTimeout = ipcTimeout;
            bindingFrmaes.ReceiveTimeout = new TimeSpan(100, 0, 0);
            bindingFrmaes.OpenTimeout = ipcTimeout;
            bindingFrmaes.CloseTimeout = ipcTimeout;
            bindingFrmaes.MaxBufferPoolSize = 2147483647;
            bindingFrmaes.MaxBufferPoolSize = 2147483647;
            bindingFrmaes.MaxReceivedMessageSize = 2147483647;
            serviceHostFrames.AddServiceEndpoint(typeof(IFramesTimeMachineGameService), bindingFrmaes, ipcAddressFrames);
            serviceHostFrames.Open();
            return serviceHostFrames;
        }

        //KEYS COMMAND LISTENER
        private static ServiceHost StartKeysListener(string player)
        {
            TimeSpan ipcTimeout = new TimeSpan(0, 0, 1);
            string ipcAddressKeys = "net.pipe://localhost/KeysTimeMachineIPC" + player;

            ServiceHost serviceHostKeys = new ServiceHost(typeof(TimeMachineGameService));
            NetNamedPipeBinding bindingKeys = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            bindingKeys.SendTimeout = ipcTimeout;
            bindingKeys.ReceiveTimeout = new TimeSpan(100, 0, 0); 
            bindingKeys.OpenTimeout = ipcTimeout;
            bindingKeys.CloseTimeout = ipcTimeout;
            bindingKeys.MaxBufferPoolSize = 2147483647;
            bindingKeys.MaxBufferPoolSize = 2147483647;
            bindingKeys.MaxReceivedMessageSize = 2147483647;
            serviceHostKeys.AddServiceEndpoint(typeof(IKeysTimeMachineGameService), bindingKeys, ipcAddressKeys);
            serviceHostKeys.Open();
            return serviceHostKeys;
        }

        //INFORMATION COMMAND LISTENER
        private static ServiceHost StartInformationListener(string player)
        {
            TimeSpan ipcTimeout = new TimeSpan(0, 0, 1);
            string ipcAddressFrames = "net.pipe://localhost/InformationTimeMachineIPC" + player;

            ServiceHost serviceHostFrames = new ServiceHost(typeof(TimeMachineGameService));
            NetNamedPipeBinding bindingFrmaes = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            bindingFrmaes.SendTimeout = ipcTimeout;
            bindingFrmaes.ReceiveTimeout = new TimeSpan(100, 0, 0);
            bindingFrmaes.OpenTimeout = ipcTimeout;
            bindingFrmaes.CloseTimeout = ipcTimeout;
            bindingFrmaes.MaxBufferPoolSize = 2147483647;
            bindingFrmaes.MaxBufferPoolSize = 2147483647;
            bindingFrmaes.MaxReceivedMessageSize = 2147483647;
            serviceHostFrames.AddServiceEndpoint(typeof(IInformationTimeMachineGameService), bindingFrmaes, ipcAddressFrames);
            serviceHostFrames.Open();
            return serviceHostFrames;
        }

        //SELECT WORLD LISTENER
        private static void StartWorldSelectListener()
        {
            TimeSpan ipcTimeout = new TimeSpan(0, 1, 0);
            string ipcAddressKeys = "net.pipe://localhost/WorldTimeMachineIPC";

            ServiceHost serviceHostKeys = new ServiceHost(typeof(TimeMachineGameService));
            NetNamedPipeBinding bindingKeys = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            bindingKeys.SendTimeout = ipcTimeout;
            bindingKeys.ReceiveTimeout = new TimeSpan(100, 0, 0);
            bindingKeys.OpenTimeout = ipcTimeout;
            bindingKeys.CloseTimeout = ipcTimeout;
            bindingKeys.MaxBufferPoolSize = 2147483647;
            bindingKeys.MaxBufferPoolSize = 2147483647;
            bindingKeys.MaxReceivedMessageSize = 2147483647;
            serviceHostKeys.AddServiceEndpoint(typeof(ISelectWorldTimeMachineGameService), bindingKeys, ipcAddressKeys);
            serviceHostKeys.Open();
        }


    }
}
