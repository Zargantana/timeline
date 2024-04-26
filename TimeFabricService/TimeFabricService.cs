using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeFabric;
using SharedModels;
using System.ServiceModel;

namespace TimeFabricService
{
    

    public class TimeFabricService: IKeysTimeFabricService
    {
        private static WorldEngine GameEngine = new WorldEngine();

        public void Start()
        {
            GameEngine.Start("data source=(local)\\SQLEXPRESS2K14;initial catalog=TimeMachine;Integrated Security=true;");

            //KEYS COMMAND LISTENER
            StartKeysListener();
        }

        public void Stop()
        {
            GameEngine.Stop();
        }

        //KEYS COMMAND LISTENER
        private static void StartKeysListener()
        {
            string ipcAddressKeys = "net.tcp://127.0.0.1:5550/WorldEngine";

            ServiceHost serviceHostKeys = new ServiceHost(typeof(TimeFabricService));
            NetTcpBinding bindingKeys = new NetTcpBinding();
            serviceHostKeys.AddServiceEndpoint(typeof(IKeysTimeFabricService), bindingKeys, ipcAddressKeys);
            serviceHostKeys.Open();
        }

        //IKeysTimeFabricService
        public void SetKeyStrokes(string player, TFKeyStrokes Keys)
        {
            //TODO: Seleccionar a que engine hay que mandarlo...
            GameEngine.SetKeyStrokes(player, Keys);
        }
    }
}
