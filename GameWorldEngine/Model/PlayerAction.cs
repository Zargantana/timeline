using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class PlayerAction
    {
        public const string PLAYER_ACTION_FACE = "Face";
        public const string PLAYER_ACTION_MOVE = "Move";
        public const string PLAYER_ACTION_INTERACT = "Interact";

        public DateTime StartTimestamp;
        public string PlayerUID;
        public string Type;

        public PlayerAction(string playerUID)
        {
            PlayerUID = playerUID;
            StartTimestamp = DateTime.Now;
        }
    }

    public class PlayerMove : PlayerAction 
    {
        public int Direction; //clockwise 1:North 2:East 3:South 4:West

        public PlayerMove(string playerUID, int direction): base(playerUID)
        {
            Direction = direction;
            Type = PLAYER_ACTION_MOVE;
        }
    }

    public class PlayerFace : PlayerAction
    {
        public int Direction; //clockwise 1:North 2:East 3:South 4:West

        public PlayerFace(string playerUID, int direction) : base(playerUID)
        {
            Direction = direction;
            Type = PLAYER_ACTION_FACE;
        }
    }

    public class PlayerInteract: PlayerAction
    {
        public PlayerInteract(string playerUID) : base(playerUID)
        {
            Type = PLAYER_ACTION_INTERACT;
        }
    }

    public class PlayersActionsQueue: List<PlayerAction>
    { }
}

