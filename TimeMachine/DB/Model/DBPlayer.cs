using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachine.DB.Model
{
    public class DBPlayer
    {
        //DBPlayer
        public string UID { get; set; }
        public int Player_X { get; set; }
        public int Player_Y { get; set; }
        public int Movement { get; set; } //0: no movement. Next clockwise 1:North 2:East 3:South 4:West
        public int Facing { get; set; }//clockwise 1:North 2:East 3:South 4:West
        public bool Moved { get; set; }
        public DateTime MovementStart { get; set; } //If movement != 0 when it was started
        public double PlayerMoveSpeed { get; set; } //MoveSpeed * 1000 = seconds moving
    }
}
