using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SharedModels
{
    /// <summary>
    /// Interface for TimeMachineGameService
    /// </summary>
    [ServiceContract(Namespace = "")]
    public interface IInformationTimeMachineGameService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        [OperationContract]
        TMInformation GetPalyerInformation(string player);
    }
}

