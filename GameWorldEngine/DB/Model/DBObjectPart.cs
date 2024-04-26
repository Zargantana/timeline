using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class DBObjectPart
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Image { get; set; }
        public int LightStrength { get; set; }
        public int LightTiles { get; set; }
        public double LightFactor { get; set; }
        public bool LightSwitch { get; set; }
        public bool LightSwitchStatus { get; set; }
        public bool Traspassable{ get; set; }
        public bool Cutview { get; set; }
        public bool Invulnerable { get; set; }
        public int  PV { get; set; }
    }

    public class DBObjectPartList : Dictionary<string, DBObjectPart>
    { }
}
