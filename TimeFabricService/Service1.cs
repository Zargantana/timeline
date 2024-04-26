using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TimeFabric;

namespace TimeFabricService
{
    public partial class Service1 : ServiceBase
    {
        private TimeFabricService GamesEnginesManager = new TimeFabricService();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //System.Threading.Thread.Sleep(10000);
            GamesEnginesManager.Start();
        }

        protected override void OnStop()
        {
            GamesEnginesManager.Stop();
        }
    }
}
