using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimeMachineService
{
    public partial class WindowsService : ServiceBase
    {
        private TimeMachineGameService ConnectionsManager = new TimeMachineGameService();


        public WindowsService()
        {
            InitializeComponent();            
        }

        protected override void OnStart(string[] args)
        {
            //Thread.Sleep(10000);
            ConnectionsManager.Start();
        }

        protected override void OnStop()
        {
            ConnectionsManager.Stop();
        }
    }
}
