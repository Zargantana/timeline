using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels;
using System.ServiceModel;

namespace TimeLineNET
{
    public class WorldSelectConnector
    {
        ISelectWorldTimeMachineGameService _SelectWorld = null;
        
        public WorldSelectConnector()
        {
            StartConnector();
        }

        public void StartConnector()
        {
            TimeSpan ipcTimeout = new TimeSpan(0, 1, 0);
            string ipcAddress = "net.pipe://localhost/WorldTimeMachineIPC";

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress endpointAddress = new EndpointAddress(ipcAddress);

            binding.SendTimeout = ipcTimeout;
            binding.OpenTimeout = ipcTimeout;
            binding.CloseTimeout = ipcTimeout;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxReceivedMessageSize = 2147483647;
            _SelectWorld = ChannelFactory<ISelectWorldTimeMachineGameService>.CreateChannel(binding, endpointAddress);
        }

        public void RestartConnector()
        {
            _SelectWorld = null;
            GC.Collect();
            StartConnector();
        }

        public void SelectOrCreateWorld(string player, string worldName)
        {
            try
            {
                _SelectWorld.SelectOrCreateWorld(player, worldName);
            }
            catch(Exception e1)
            {
                RestartConnector();
                try
                {
                    _SelectWorld.SelectOrCreateWorld(player, worldName);
                }
                catch (Exception e2)
                {
                    throw e2;
                }
            }
        }
    }
}
