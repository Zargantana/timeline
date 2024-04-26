using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class DBPlayer
    {
        public int Movement { get; set; } //0: no movement. Next clockwise 1:North 2:East 3:South 4:West
        //public bool Action { get; set; } //true si está relaizando algo: atacar, pocion, magia, esconderse, ...
        public int Facing { get; set; }//clockwise 1:North 2:East 3:South 4:West
        public DateTime Facing_Timestamp { get; set; }
        public DateTime MovementStart { get; set; } //If movement != 0 when it was started
        public double PlayerMoveSpeed { get; set; }
        public bool Moved { get; set; }
        public int Initiative { get; set; }
        public string UID { get; set; }
        public int Tile_X;
        public int Tile_Y;
        public int LightStrength { get; set; }
        public int LightTiles { get; set; }
        public double LightFactor { get; set; }
        public DateTime AttackStart { get; set; } //If (!Attack),  when it was started
        public double AttackSpeed { get; set; }
        public bool Attacked { get; set; }
        public DateTime Interact_Timestamp { get; set; }
    }

    public class DBPlayerList: Dictionary<string, DBPlayer>
    { }

}

