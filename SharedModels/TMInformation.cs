using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class TMInformation
    {
        public string North { get; set; }
        public string South { get; set; }
        public string West { get; set; }
        public string East { get; set; }
        public string Position { get; set; }
        public TMPlayerStats Stats { get; set; }
    }

    public class TMPlayerStats
    {
        public string PV { get; set; }
        public string Initiative { get; set; }
        public string MovementSpeed { get; set; }
    }

    
}
