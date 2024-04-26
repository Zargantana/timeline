using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels;
using System.ServiceModel;

namespace TimeLineNET
{
    public class KeysConnector
    {
        private static Dictionary<string, IKeysTimeMachineGameService> KeysConnections = new Dictionary<string, IKeysTimeMachineGameService>();

        public IKeysTimeMachineGameService StartConnector(string player)
        {
            TimeSpan ipcTimeout = new TimeSpan(0, 0, 1);
            string ipcAddress = "net.pipe://localhost/KeysTimeMachineIPC" + player;

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress endpointAddress = new EndpointAddress(ipcAddress);

            binding.SendTimeout = ipcTimeout;
            binding.OpenTimeout = ipcTimeout;
            binding.CloseTimeout = ipcTimeout;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxReceivedMessageSize = 2147483647;
            return ChannelFactory<IKeysTimeMachineGameService>.CreateChannel(binding, endpointAddress);
        }

        private IKeysTimeMachineGameService Connector(string player)
        {
            if (!KeysConnections.ContainsKey(player)) KeysConnections.Add(player, StartConnector(player));
            return KeysConnections[player];
        }

        public void RestartConnector(string player)
        {
            KeysConnections.Remove(player);
            GC.Collect();
        }

        public void SetKeystrokes(string player, TMKeyStrokes keys)
        {
            try
            {
                Connector(player).SetKeystrokes(player,  keys);
            }
            catch //(Exception e1)
            {
                RestartConnector(player);
                try
                {
                    Connector(player).SetKeystrokes(player, keys);
                }
                catch //(Exception e2)
                { }
            }
        }
    }
}
