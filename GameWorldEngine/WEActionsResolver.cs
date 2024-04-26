using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class WEActionsResolver
    {
        SqlConnection connection;
        SqlTransaction Transaction;
        public void ResolvePlayerActions(PlayersActionsQueue PlayerActionsQueue, DBPlayerList PlayerList, SqlConnection _connection, SqlTransaction _Transaction)
        {
            connection = _connection;
            Transaction = _Transaction;
            //Para cada PlayerAction en PlayerActionsQueue
            foreach (PlayerAction playerAction in PlayerActionsQueue)
            {
                DBPlayer Player = PlayerList[playerAction.PlayerUID];

                if (playerAction.Type  == PlayerAction.PLAYER_ACTION_MOVE) ResolveMove(playerAction.PlayerUID, Player, (PlayerMove)playerAction);
                else if (playerAction.Type == PlayerAction.PLAYER_ACTION_FACE) ResolveFace(playerAction.PlayerUID, Player, (PlayerFace)playerAction);
                else if (playerAction.Type == PlayerAction.PLAYER_ACTION_INTERACT) ResolveInteract(playerAction.PlayerUID, Player, (PlayerInteract)playerAction);
                //if ATTACK startAction at DB
                //if use hability start it at DB
            }
            connection = null;
            Transaction = null;
        }

        private void ResolveMove(string PlayerUID, DBPlayer Player, PlayerMove playerMove)
        {
            // NUNCA LLEGA SI YA TIENE MOVIMIETO POR KEYSRESOLVER
            /*if (Player.Movement != 0)
            {
                if (playerMove.Direction != Player.Movement)
                {
                    if (BeforeHalfMove(Player.MovementStart, playerMove.StartTimestamp, Player.PlayerMoveSpeed))
                    {

                    }
                }
            }
            else
            {
                Player.Facing = Player.Movement = playerMove.Direction;
                Player.MovementStart = playerMove.StartTimestamp;
            }*/
            Player.Facing = Player.Movement = playerMove.Direction;
            Player.MovementStart = playerMove.StartTimestamp;
            Player.Moved = false;
            (new DBPlayerWriter()).WriteMove(PlayerUID, Player.Movement, Player.MovementStart, connection, Transaction);
        }

        private void ResolveFace(string PlayerUID, DBPlayer Player, PlayerFace playerFace)
        {
            Player.Facing = playerFace.Direction;
            Player.Facing_Timestamp = playerFace.StartTimestamp;
            (new DBPlayerWriter()).WriteFace(PlayerUID, Player.Facing, Player.Facing_Timestamp, connection, Transaction);
        }

        private void ResolveInteract(string PlayerUID, DBPlayer Player, PlayerInteract playerInteract)
        {
            int X = Player.Tile_X, Y = Player.Tile_Y;

            Player.Interact_Timestamp = playerInteract.StartTimestamp;
            switch (Player.Facing)
            {
                case 1: { Y--; break; }
                case 2: { X++; break; }
                case 3: { Y++; break; }
                case 4: { X--; break; }
            }
            DBObjectPart dBObjectPart = (new DBObjectsReader()).ReadObjectPart(connection, Transaction, X, Y);
            if (dBObjectPart != null) InteractObjectStack(PlayerUID, playerInteract.StartTimestamp, dBObjectPart);
        }

        private void InteractObjectStack(string PlayerUID, DateTime Interact_Timestamp, DBObjectPart dBObjectPart)
        {
            if (dBObjectPart.LightSwitch)
            {
                (new DBObjectsWriter()).WriteLightSwithcStatus(connection, Transaction, dBObjectPart.UID, !dBObjectPart.LightSwitchStatus);
                (new DBPlayerWriter()).WriteInteract(PlayerUID, Interact_Timestamp, connection, Transaction);
            }
            else if (true) { }//More stacked actions
        }

        /*
        private void ResolveAttack(DBPlayer Player)
        {
            
        }
        */

    }
}

