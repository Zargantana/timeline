using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels;
using System.ServiceModel;

namespace TimeLineNET
{
    public class FramesConnector
    {
        private const string FAILURE_GIF = "R0lGODlhHAAdAHAAACH5BAEAAPwALAAAAAAcAB0AhwAAAAAAMwAAZgAAmQAAzAAA/wArAAArMwArZgArmQArzAAr/wBVAABVMwBVZgBVmQBVzABV/wCAAACAMwCAZgCAmQCAzACA/wCqAACqMwCqZgCqmQCqzACq/wDVAADVMwDVZgDVmQDVzADV/wD/AAD/MwD/ZgD/mQD/zAD//zMAADMAMzMAZjMAmTMAzDMA/zMrADMrMzMrZjMrmTMrzDMr/zNVADNVMzNVZjNVmTNVzDNV/zOAADOAMzOAZjOAmTOAzDOA/zOqADOqMzOqZjOqmTOqzDOq/zPVADPVMzPVZjPVmTPVzDPV/zP/ADP/MzP/ZjP/mTP/zDP//2YAAGYAM2YAZmYAmWYAzGYA/2YrAGYrM2YrZmYrmWYrzGYr/2ZVAGZVM2ZVZmZVmWZVzGZV/2aAAGaAM2aAZmaAmWaAzGaA/2aqAGaqM2aqZmaqmWaqzGaq/2bVAGbVM2bVZmbVmWbVzGbV/2b/AGb/M2b/Zmb/mWb/zGb//5kAAJkAM5kAZpkAmZkAzJkA/5krAJkrM5krZpkrmZkrzJkr/5lVAJlVM5lVZplVmZlVzJlV/5mAAJmAM5mAZpmAmZmAzJmA/5mqAJmqM5mqZpmqmZmqzJmq/5nVAJnVM5nVZpnVmZnVzJnV/5n/AJn/M5n/Zpn/mZn/zJn//8wAAMwAM8wAZswAmcwAzMwA/8wrAMwrM8wrZswrmcwrzMwr/8xVAMxVM8xVZsxVmcxVzMxV/8yAAMyAM8yAZsyAmcyAzMyA/8yqAMyqM8yqZsyqmcyqzMyq/8zVAMzVM8zVZszVmczVzMzV/8z/AMz/M8z/Zsz/mcz/zMz///8AAP8AM/8AZv8Amf8AzP8A//8rAP8rM/8rZv8rmf8rzP8r//9VAP9VM/9VZv9Vmf9VzP9V//+AAP+AM/+AZv+Amf+AzP+A//+qAP+qM/+qZv+qmf+qzP+q///VAP/VM//VZv/Vmf/VzP/V////AP//M///Zv//mf//zP///wAAAAAAAAAAAAAAAAj/APcJ3DcpU0GDmRAqPHhwoMN9aCRNSiOR4sSKGCehyfSQYCYCCgwAOCCSZAADB0aWPOCCRkKHYtAUKEAlm7Rs2G5Ky2lTZ4ACBCQ6RDMpQIAB2QYoXcqUgxhAAwKwcDNpID00aAAAKJDKBYGZ2L59A1RAwQhsXgEYmFR1oJhJWgtwAUTgq7Rw4QpdiAAhVV0AKjYOzfqTADagBbCBM2doRIdUVwoMGMkWJlwAX1O1yGwOHKAFCg7/VZEGE8ysWwlcMQT0Tzhzm63Q/bu2rUCice1+tWLOXGS0XycHkPTmdG4Cr7wW2FmgxSugtCsPxJ26wJU/QK+0KADoSl3JAIZz7RS4LObxxAWsgCuHHvHk2kMnCRggoL6AVywEfHu14o/9+vRN4sZpM2mllQqoGKigVoUJNVAmxNCQw4LZLLigDmQko0xH1BmIigoWahUDJuMJpIwyEIYhRogsAiCGGJoQcyIaK7Zoo4IFvUgUVjymgZWPkvj4Y0RAonEDah0lqeRAAMTQpEDt0OOOOx1BqAwxMmJ5pUBNaiUQKmCi0pGN+9QDwA1P7vPKft90FMMNb8YJpxhcOgnAkng6BM2ZT9KzzzL61BMNPdHUow+gy+xDqKGF6lNokxrdKCkAmYiRUAxi3JDpppp2yumnmiYUEAA7";
        //IFramesTimeMachineGameService _Frames = null;
        private static Dictionary<string, IFramesTimeMachineGameService> FramesConnections = new Dictionary<string, IFramesTimeMachineGameService>();

        public IFramesTimeMachineGameService StartConnector(string player)
        {
            TimeSpan ipcTimeout = new TimeSpan(0, 0, 1);
            string ipcAddress = "net.pipe://localhost/FramesTimeMachineIPC" + player;

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress endpointAddress = new EndpointAddress(ipcAddress);

            binding.SendTimeout = ipcTimeout;
            binding.OpenTimeout = ipcTimeout;
            binding.CloseTimeout = ipcTimeout;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxReceivedMessageSize = 2147483647;
            return ChannelFactory<IFramesTimeMachineGameService>.CreateChannel(binding, endpointAddress);
        }

        private IFramesTimeMachineGameService Connector(string player)
        {
            if (!FramesConnections.ContainsKey(player)) FramesConnections.Add(player, StartConnector(player));
            return FramesConnections[player];
        }
        
        public void RestartConnector(string player)
        {
            FramesConnections.Remove(player);
            GC.Collect();
        }
        
        public string GetPlayerFrame(string player)
        {
            try
            {
                string _local = Connector(player).GetPalyerFrame(player);
                return _local;
            }
            catch(Exception e1)
            {
                RestartConnector(player);
                try
                {
                    return Connector(player).GetPalyerFrame(player);
                }
                catch (Exception e2)
                {
                    return FAILURE_GIF;
                }
            }
        }
    }
}
