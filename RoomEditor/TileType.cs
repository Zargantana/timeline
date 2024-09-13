using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEditor
{
    public class TileType
    {
        public string UID;
        public string NAME;
        public string IMAGE;
        public bool CUTVIEW;
        public int DARKNESS;
        public bool TRASPASSABLE;

        public override string ToString()
        {
            return NAME;
        }
    }
}
