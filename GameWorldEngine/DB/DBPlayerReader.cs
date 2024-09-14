using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseTypes;
using System.Collections.Specialized;

namespace TimeFabric
{
    public class DBPlayerReader
    {
        public const int MAX_ROOM_PLAYERS = 128;
        private const string PL_QUERYSTRING = "SELECT UID, MOVEMENT_SPEED, MOVEMENT, MOVEMENT_TIMESTAMP, MOVED, FACING, FACING_TIMESTAMP, INITIATIVE, ROOM_TILE_GRID_X, ROOM_TILE_GRID_Y," +
            " [LIGHTNING], [LIGHTNING_TILES], [LIGHTNING_FACTOR], [ATTACK_SPEED], [ATTACK_TIMESTAMP], [ATTACKED], [INTERACT_TIMESTAMP] " +
            "FROM PLAYERS ORDER BY INITIATIVE, UID DESC";
        public DBPlayerList ReadPlayerList(SqlConnection connection, SqlTransaction Transaction, out DBPlayer[] InitiativePlayers)
        {
            DBPlayerList dBPlayerList = new DBPlayerList();
            InitiativePlayers = new DBPlayer[MAX_ROOM_PLAYERS];
            //Read from DB.
            SqlCommand command = new SqlCommand(PL_QUERYSTRING, connection, Transaction);
            try
            {
                SqlDataReader playersReader = command.ExecuteReader();
                try
                {
                    DBPlayer dBPlayer;
                    
                    int count = 0;
                    while (playersReader.Read())//Por row
                    {
                        dBPlayer = new DBPlayer();

                        dBPlayer.UID = ((Guid)playersReader[0]).ToString();
                        dBPlayer.PlayerMoveSpeed = Types.DBDoubleToDouble((string)playersReader[1], 1.0f);
                        dBPlayer.Movement = (int)playersReader[2];
                        dBPlayer.MovementStart = (DateTime)playersReader[3];
                        dBPlayer.Moved = Types.DBBoolToBoolean((string)playersReader[4]);
                        dBPlayer.Facing = (int)playersReader[5];
                        dBPlayer.Facing_Timestamp = (DateTime)playersReader[6];
                        dBPlayer.Initiative = (int)playersReader[7];
                        dBPlayer.Tile_X = (int)playersReader[8];
                        dBPlayer.Tile_Y = (int)playersReader[9];
                        dBPlayer.LightStrength = (int)playersReader[10];
                        dBPlayer.LightTiles = (int)playersReader[11];
                        dBPlayer.LightFactor = Types.DBDoubleToDouble((string)playersReader[12], 1.0f);
                        dBPlayer.AttackSpeed = Types.DBDoubleToDouble((string)playersReader[13], 1.0f);
                        dBPlayer.AttackStart = (DateTime)playersReader[14];
                        dBPlayer.Attacked = Types.DBBoolToBoolean((string)playersReader[15]);
                        dBPlayer.Interact_Timestamp = (DateTime)playersReader[16];

                        dBPlayerList.Add(dBPlayer.UID, dBPlayer);
                        InitiativePlayers[count++] = dBPlayer;
                    }
                    Array.Resize<DBPlayer>(ref InitiativePlayers, count);
                }
                finally
                {
                    try
                    {
                        playersReader.Close();
                        playersReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dBPlayerList;
        }

        private const string CM_QUERYSTRING = "SELECT CASE WHEN COUNT(0) = 0 THEN 'true' ELSE 'false' END FROM PLAYERS P,TILES T, OBJECT_PARTS OP WHERE" +
            "((P.ROOM_TILE_GRID_X = @Tile_X AND P.ROOM_TILE_GRID_Y = @Tile_Y) OR (T.TRASPASSABLE = 'false' AND T.ROOM_TILE_GRID_X = @Tile_X AND T.ROOM_TILE_GRID_Y = @Tile_Y) " +
            "OR (OP.TRASPASSABLE = 'false' AND OP.ROOM_TILE_GRID_X = @Tile_X AND OP.ROOM_TILE_GRID_Y = @Tile_Y))";
        public bool ReadCanMove(SqlConnection connection, SqlTransaction Transaction, int Tile_x, int Tile_y)
        {
            bool result = false;
            //Read from DB.
            SqlCommand command = new SqlCommand(CM_QUERYSTRING, connection, Transaction);
            command.Parameters.AddWithValue("@Tile_X", Tile_x);
            command.Parameters.AddWithValue("@Tile_Y", Tile_y);
            try
            {
                SqlDataReader CanReader = command.ExecuteReader();
                try
                {
                    if (CanReader.Read())
                    {
                        var a = (string)CanReader[0];
                        result = Types.DBBoolToBoolean((string)CanReader[0]);
                    }
                }
                finally
                {
                    try
                    {
                        CanReader.Close();
                        CanReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
