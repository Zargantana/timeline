using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TimeMachine.DB.Model;
using DataBaseTypes;

namespace TimeMachine.DB
{
    public class PlayerReader
    {
        private string player;

        //The player
        public DBPlayer dBPlayer = new DBPlayer();
        private const string QUERYSTRING = "SELECT UID, MOVEMENT_SPEED, MOVEMENT, MOVEMENT_TIMESTAMP, FACING, MOVED, ROOM_TILE_GRID_X, ROOM_TILE_GRID_Y FROM PLAYERS WHERE PLAYERS.UID = @player";

        //Other players
        public List<DBPlayer> dBOtherPlayers = new List<DBPlayer>();
        private const string QUERYSTRING_OTHERS = "SELECT UID, MOVEMENT_SPEED, MOVEMENT, MOVEMENT_TIMESTAMP, FACING, MOVED, ROOM_TILE_GRID_X, ROOM_TILE_GRID_Y FROM PLAYERS WHERE PLAYERS.UID <> @player";

        //Constructor
        public PlayerReader(string _player) : base()
        {
            player = _player;            
        }

        //Get The player
        public void GetPlayer(SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(QUERYSTRING, connection, transaction);
            command.Parameters.AddWithValue("@player", player);
            try
            {
                SqlDataReader positionReader = command.ExecuteReader();
                try
                {
                    if (positionReader.Read())
                    {
                        dBPlayer.UID = ((Guid)positionReader[0]).ToString();
                        dBPlayer.PlayerMoveSpeed = Types.DBDoubleToDouble((string)positionReader[1], 1);
                        dBPlayer.Movement = (int)positionReader[2];
                        dBPlayer.MovementStart = (DateTime)positionReader[3];
                        dBPlayer.Facing = (int)positionReader[4];
                        dBPlayer.Moved = Types.DBBoolToBoolean((string)positionReader[5]);
                        dBPlayer.Player_X = (int)positionReader[6];
                        dBPlayer.Player_Y = (int)positionReader[7];                        
                    }
                }
                finally
                {
                    try
                    {
                        positionReader.Close();
                        positionReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetOtherPlayers(SqlConnection connection, SqlTransaction transaction)
        {
            dBOtherPlayers.Clear();
            //At the end of the gameTick is called;
            //GC.Collect();

            SqlCommand command = new SqlCommand(QUERYSTRING_OTHERS, connection, transaction);
            command.Parameters.AddWithValue("@player", player);
            try
            {
                SqlDataReader positionReader = command.ExecuteReader();
                try
                {
                    
                    while (positionReader.Read())
                    {
                        DBPlayer _local = new DBPlayer();

                        _local.UID = ((Guid)positionReader[0]).ToString();
                        _local.PlayerMoveSpeed = Types.DBDoubleToDouble((string)positionReader[1], 1);
                        _local.Movement = (int)positionReader[2];
                        _local.MovementStart = (DateTime)positionReader[3];
                        _local.Facing = (int)positionReader[4];
                        _local.Moved = Types.DBBoolToBoolean((string)positionReader[5]);
                        _local.Player_X = (int)positionReader[6];
                        _local.Player_Y = (int)positionReader[7];

                        dBOtherPlayers.Add(_local);
                    }
                }
                finally
                {
                    try
                    {
                        positionReader.Close();
                        positionReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

