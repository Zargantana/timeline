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
        public string Image { get; set; }
        public bool Cutview { get; set; }
        public bool Traspassable { get; set; }
        public bool Above { get; set; }
    }
}
