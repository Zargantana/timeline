using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels;
using System.ServiceModel;

namespace TimeLineNET
{
    public class InformationConnector
    {
        private const string FAILURE_INFO = "{}";
        private static Dictionary<string, IInformationTimeMachineGameService> InformationConnections = new Dictionary<string, IInformationTimeMachineGameService>();

        public IInformationTimeMachineGameService StartConnector(string player)
        {
            TimeSpan ipcTimeout = new TimeSpan(0, 0, 1);
            string ipcAddress = "net.pipe://localhost/InformationTimeMachineIPC" + player;

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress endpointAddress = new EndpointAddress(ipcAddress);

            binding.SendTimeout = ipcTimeout;
            binding.OpenTimeout = ipcTimeout;
            binding.CloseTimeout = ipcTimeout;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxReceivedMessageSize = 2147483647;
            return ChannelFactory<IInformationTimeMachineGameService>.CreateChannel(binding, endpointAddress);
        }

        private IInformationTimeMachineGameService Connector(string player)
        {
            if (!InformationConnections.ContainsKey(player)) InformationConnections.Add(player, StartConnector(player));
            return InformationConnections[player];
        }
        
        public void RestartConnector(string player)
        {
            InformationConnections.Remove(player);
            GC.Collect();
        }
        
        public TMInformation GetPlayerInformation(string player)
        {
            try
            {
                TMInformation _local = Connector(player).GetPalyerInformation(player);
                return _local;
            }
            catch(Exception e1)
            {
                RestartConnector(player);
                try
                {
                    return Connector(player).GetPalyerInformation(player);
                }
                catch (Exception e2)
                {
                    //return FAILURE_INFO;
                    return new TMInformation();
                }
            }
        }
    }
}
