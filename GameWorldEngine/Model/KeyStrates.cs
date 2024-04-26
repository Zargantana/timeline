using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class KeysState
    {
        private bool _left;
        private bool _right;
        private bool _up;
        private bool _down;

        private bool _interact;
        private bool _attack;

        public bool Left { get { return _left; } set { if (!_left && value) { PullLeft = true; } _left = value; } }
        public bool Right { get { return _right; } set { if (!_right && value) { PullRight = true; } _right = value; } }
        public bool Up { get { return _up; } set { if (!_up && value) { PullUp = true; } _up = value; } }
        public bool Down { get { return _down; } set { if (!_down && value) { PullDown = true; } _down = value; } }

        public bool Interact { get { return _interact; } set { if (!_interact && value) { PullInteract = true; } _interact = value; } }
        public bool Attack { get { return _attack; } set { if (!_attack && value) { PullAttack = true; } _down = value; } }

        public bool PullLeft { get; set; }
        public bool PullRight { get; set; }
        public bool PullUp { get; set; }
        public bool PullDown { get; set; }
        
        public bool PullInteract { get; set; }
        public bool PullAttack { get; set; }
    }

    public class KeysStatesList:  Dictionary<string, KeysState>
    { }
}
