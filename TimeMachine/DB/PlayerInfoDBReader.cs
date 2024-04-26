using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModels;

namespace TimeMachine.DB
{
    /// <summary>
    /// Lee de la BD la info en el formato necesario para devolver la info a mostrar en pantalla.
    /// TODO: Debe tener en cuenta:
    ///     - Reconexiones --> timeout --> Que la BD ya no existe.
    ///     - Que el player ya no esté en BD.
    ///     - 
    /// </summary>
    public class PlayerInfoDBReader: IDisposable
    {
        private SqlConnection connection;//To open it once
        private SqlDataReader PlayerInfoReader;
        private string connectionString;//For reconnecting
        private string player;
        public TMInformation PlayerInformation;

        public PlayerInfoDBReader(string playerUID, string _connectionstring) : base()
        {
            connectionString = _connectionstring;
            connection = new SqlConnection(_connectionstring);
            connection.Open();
            player = playerUID;
        }

        public void ReadPlayerInfoData()
        {
            SqlTransaction sqlTransaction;

            StartReadingPlayerInfo(out sqlTransaction);

            try
            {
                //No le paso la conneciton aqui, porque si la he de resetear, mejor que no tenga que volver a crear todo... 
                //Total, pasar un puntero no ha de tardar tanto.
                GetPlayerData(sqlTransaction);

                //End transaction
                sqlTransaction.Commit();
            }
            catch(Exception e)
            {
                sqlTransaction.Rollback();
            }
        }

        private void StartReadingPlayerInfo(out SqlTransaction sqlTransaction)
        {
            sqlTransaction = connection.BeginTransaction(IsolationLevel.Snapshot);
        }

        private static readonly string QUERYSTRING = 
"DECLARE @X AS INT " +
"DECLARE @Y AS INT " +
" " +
"SELECT @X = ROOM_TILE_GRID_X, @Y = ROOM_TILE_GRID_Y FROM PLAYERS WHERE UID = @player " +
" " +
"DECLARE @POSITION AS nvarchar(128) " +
"SET @POSITION = 'Nothing' " +
"SELECT  " +
"		@POSITION = '(' + OBJ.NAME + ') ' + OP.NAME  " +
"FROM  " +
"	OBJECT_PARTS OP " +
"	INNER JOIN REL_OBJECTS_AND_PARTS REL ON OP.UID = REL.OBJECT_PART " +
"	INNER JOIN [OBJECTS] OBJ ON REL.OBJECT = OBJ.UID " +
"WHERE  " +
"	OP.ROOM_TILE_GRID_X = @X AND  " +
"	OP.ROOM_TILE_GRID_Y = @Y " +
" " +
"DECLARE @NORTH AS nvarchar(128) " +
"SET @NORTH = 'Nothing' " +
"SELECT  " +
"		@NORTH = '(' + OBJ.NAME + ') ' + OP.NAME  " +
"FROM  " +
"	OBJECT_PARTS OP " +
"	INNER JOIN REL_OBJECTS_AND_PARTS REL ON OP.UID = REL.OBJECT_PART " +
"	INNER JOIN [OBJECTS] OBJ ON REL.OBJECT = OBJ.UID " +
"WHERE  " +
"	OP.ROOM_TILE_GRID_X = @X AND  " +
"	OP.ROOM_TILE_GRID_Y = (@Y - 1) " +
" " +
"DECLARE @SOUTH AS nvarchar(128) " +
"SET @SOUTH = 'Nothing' " +
"SELECT  " +
"		@SOUTH = '(' + OBJ.NAME + ') ' + OP.NAME  " +
"FROM  " +
"	OBJECT_PARTS OP " +
"	INNER JOIN REL_OBJECTS_AND_PARTS REL ON OP.UID = REL.OBJECT_PART " +
"	INNER JOIN [OBJECTS] OBJ ON REL.OBJECT = OBJ.UID " +
"WHERE  " +
"	OP.ROOM_TILE_GRID_X = @X AND  " +
"	OP.ROOM_TILE_GRID_Y = (@Y + 1) " +
" " +
"DECLARE @WEST AS nvarchar(128) " +
"SET @WEST = 'Nothing' " +
"SELECT  " +
"		@WEST = '(' + OBJ.NAME + ') ' + OP.NAME  " +
"FROM  " +
"	OBJECT_PARTS OP " +
"	INNER JOIN REL_OBJECTS_AND_PARTS REL ON OP.UID = REL.OBJECT_PART " +
"	INNER JOIN [OBJECTS] OBJ ON REL.OBJECT = OBJ.UID " +
"WHERE  " +
"	OP.ROOM_TILE_GRID_X = (@X - 1) AND  " +
"	OP.ROOM_TILE_GRID_Y = @Y " +
" " +
"DECLARE @EAST AS nvarchar(128) " +
"SET @EAST = 'Nothing' " +
"SELECT  " +
"		@EAST = '(' + OBJ.NAME + ') ' + OP.NAME  " +
"FROM  " +
"	OBJECT_PARTS OP " +
"	INNER JOIN REL_OBJECTS_AND_PARTS REL ON OP.UID = REL.OBJECT_PART " +
"	INNER JOIN [OBJECTS] OBJ ON REL.OBJECT = OBJ.UID " +
"WHERE  " +
"	OP.ROOM_TILE_GRID_X = (@X + 1) AND  " +
"	OP.ROOM_TILE_GRID_Y = @Y " +
" " +
" " +
"SELECT @NORTH AS NORTH, @SOUTH AS SOUTH, @WEST AS WEST, @EAST AS EAST, @POSITION AS POSITION";
        private void GetPlayerData(SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(QUERYSTRING, connection, transaction);
            command.Parameters.AddWithValue("@player", player);
            
            try
            {
                PlayerInfoReader = command.ExecuteReader();
                ReadNearbyObjects();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ReadNearbyObjects()
        {
            try
            {
                //GODmESUREITOR.StartMesure();
                if (PlayerInfoReader.Read())
                {
                    PlayerInformation = new TMInformation();
                    PlayerInformation.North = (string)PlayerInfoReader[0];
                    PlayerInformation.South = (string)PlayerInfoReader[1];
                    PlayerInformation.West = (string)PlayerInfoReader[2];
                    PlayerInformation.East = (string)PlayerInfoReader[3];
                    PlayerInformation.Position = (string)PlayerInfoReader[4];
                }
            }
            catch { }
            finally
            {
                try
                {
                    PlayerInfoReader.Close();
                    PlayerInfoReader = null;
                }
                catch { }
            }
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
    }
}
