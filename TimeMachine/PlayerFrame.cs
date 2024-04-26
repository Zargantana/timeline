using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TimeMachine
{
    public class PlayerFrame
    {
        public Image Sprite;
        public int X_Offset;
        public int Y_Offset;

        public PlayerFrame(): base()
        {
            X_Offset = Y_Offset = 0;
        }
    }
}
