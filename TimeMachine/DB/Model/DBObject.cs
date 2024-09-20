using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachine.DB.Model
{
    public class DBObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Cutview { get; set; }
        public bool Traspassable { get; set; }
        public bool Above { get; set; }
        public string Animation { get; set; }
        public string Animation_light_on { get; set; }
        public double Animation_speed { get; set; }
        public DateTime Animation_timestamp { get; set; }
        public bool Lightswitch { get; set; }
        public bool Lightswitch_status { get; set; }
    }
}
