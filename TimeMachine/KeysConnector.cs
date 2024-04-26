using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels;
using System.ServiceModel;

namespace TimeMachine
{
    public class KeysConnector
    {
        IKeysTimeFabricService _Keys = null;

        public KeysConnector()
        {
            StartConnector();
        }

        public void StartConnector()
        {
            string ipcAddressKeys = "net.tcp://127.0.0.1:5550/WorldEngine";

            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress endpointAddress = new EndpointAddress(ipcAddressKeys);
            _Keys = ChannelFactory<IKeysTimeFabricService>.CreateChannel(binding, endpointAddress);
        }

        public void RestartConnector()
        {
            _Keys = null;
            GC.Collect();
            StartConnector();
        }
        
        public void EnqueueKeys(string player, KeysPressed keys)
        {
            TFKeyStrokes PlayerEnqueuedKeys = new TFKeyStrokes();

            PlayerEnqueuedKeys.Up = (keys.Key_W == 1);
            PlayerEnqueuedKeys.Down = (keys.Key_S == 1);
            PlayerEnqueuedKeys.Left = (keys.Key_A == 1);
            PlayerEnqueuedKeys.Right = (keys.Key_D == 1);
            PlayerEnqueuedKeys.Interact  = (keys.Key_E == 1);
            PlayerEnqueuedKeys.Attack = (keys.Key_SP == 1);

            _Keys.SetKeyStrokes(player, PlayerEnqueuedKeys);
        }
    }
}
