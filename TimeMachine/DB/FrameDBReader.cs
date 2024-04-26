using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeMachine.DB
{
    /// <summary>
    /// Lee de la BD la info en el formato necesario para dibujar un frame.
    /// TODO: Debe tener en cuenta:
    ///     - Reconexiones --> timeout --> Que la BD ya no existe.
    ///     - Que el player ya no esté en BD.
    ///     - 
    /// </summary>
    public class FrameDBReader: IDisposable
    {
        public const int SCREEN_TILES_SIZE = 7; //Numero de tiles antes y numero de tiles despuñes del PJ de E a O y de N a S. Cuadrado centrado.        
        public const int TILE_SIZE = 28; //Tamaño en pixels de una tile

        private SqlConnection connection;//To open it once
        private string connectionString;//For reconnecting

        public PlayerReader playerPositionReader;
        public ScreenTilesReader screenTilesReader;
        public ObjectsReader objectsReader;


        public FrameDBReader(string player, string _connectionstring) : base()
        {
            connectionString = _connectionstring;
            connection = new SqlConnection(_connectionstring);
            connection.Open();

            playerPositionReader = new PlayerReader(player);
            screenTilesReader = new ScreenTilesReader();
            objectsReader = new ObjectsReader();
        }

        public void PreloadImages(out Dictionary<string, Image> Preloaded)
        {
            string ImageName;
            Image Paint;
            string QueryString = "SELECT NAME, IMAGE FROM IMAGES";
            Preloaded = new Dictionary<string, Image>();
            SqlCommand command = new SqlCommand(QueryString, connection);
            try
            {
                SqlDataReader Reader = command.ExecuteReader();
                try
                {
                    while (Reader.Read())//Por row
                    {
                        ImageName = (string)Reader[0];
                        Paint = Image.FromFile((string)Reader[1]);
                        Preloaded.Add(ImageName, Paint);
                    }
                }
                finally
                {
                    try
                    {
                        Reader.Close();
                        Reader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            { }
        }

        public void ReadFrameData()
        {
            SqlTransaction sqlTransaction;

            StartReadingForFrame(out sqlTransaction);

            try
            {
                //No les paso la conneciton aqui, porque si la he de resetear, mejor que no tenga que volver a crear todo... 
                //Total, pasar un puntero no ha de tardar tanto.
                GetPlayerData(sqlTransaction);
                GetOtherPlayersData(sqlTransaction);
                TilesForBackground(sqlTransaction);
                GetNearbyObjects(sqlTransaction);

                //Wait for all trues or timeout --> slow DB(because too much data, or hardware, or S.O.,...) or interlocked.
                while (!screenTilesReader.readed) Thread.Sleep(1);
                while (!objectsReader.readed) Thread.Sleep(0);

                //End transaction

                sqlTransaction.Commit();
            }
            catch(Exception e)
            {
                sqlTransaction.Rollback();
            }
        }

        private void StartReadingForFrame(out SqlTransaction sqlTransaction)
        {
            sqlTransaction = connection.BeginTransaction(IsolationLevel.Snapshot);
        }

        private void GetPlayerData(SqlTransaction transaction)
        {
            playerPositionReader.GetPlayer(connection, transaction);
        }

        private void GetOtherPlayersData(SqlTransaction transaction)
        {
            playerPositionReader.GetOtherPlayers(connection, transaction);
        }

        private void TilesForBackground(SqlTransaction transaction)
        {
            screenTilesReader.GetScreenTiles(connection, transaction, playerPositionReader.dBPlayer.Player_X - SCREEN_TILES_SIZE, 
                playerPositionReader.dBPlayer.Player_Y - SCREEN_TILES_SIZE, playerPositionReader.dBPlayer.Player_X + SCREEN_TILES_SIZE, 
                playerPositionReader.dBPlayer.Player_Y + SCREEN_TILES_SIZE);
        }

        private void GetNearbyObjects(SqlTransaction transaction)
        {
            objectsReader.GetNearbyObjects(connection, transaction, playerPositionReader.dBPlayer.Player_X - SCREEN_TILES_SIZE,
                playerPositionReader.dBPlayer.Player_Y - SCREEN_TILES_SIZE, playerPositionReader.dBPlayer.Player_X + SCREEN_TILES_SIZE,
                playerPositionReader.dBPlayer.Player_Y + SCREEN_TILES_SIZE);
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
    }
}
