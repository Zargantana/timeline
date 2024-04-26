using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeLineNET.Models
{
    public class KeyState
    {
        public int Key_P { get; set; }
        public int Key_O { get; set; }
        public int Key_Q { get; set; }
        public int Key_A { get; set; }
        public int Key_W { get; set; }
        public int Key_S { get; set; }
        public int Key_D { get; set; }
        public int Key_E { get; set; }
        public int Key_SP { get; set; }
    }

    public class KeysModel
    {
        public KeyState Keys { get; set; }
        public string Username { get; set; }
        //public string World { get; set; }
    }
    
}