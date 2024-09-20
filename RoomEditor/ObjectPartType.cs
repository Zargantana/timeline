using System;

namespace RoomEditor
{
    internal class ObjectPartType
    {
        public string UID;
        public string NAME;
        public int OFFSET_X;
        public int OFFSET_Y;
        public int PV;
        public bool INVULNERABLE;
        public bool CUTVIEW;
        public int LIGHTNING;
        public int LIGHTNING_TILES;
        public string LIGHTNING_FACTOR;
        public bool LIGHTSWITCH;
        public bool TRASPASSABLE;
        public bool ABOVE;
        public string ANIMATION { get; set; }
        public string ANIMATION_LIGHT_ON { get; set; }
        public double ANIMATION_SPEED { get; set; }
    }
}