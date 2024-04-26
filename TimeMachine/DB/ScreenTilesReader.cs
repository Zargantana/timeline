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
    public class ScreenTilesReader: TWorker
    {
        private Thread GetScreenTilesThread;
        private SqlDataReader TilesReader;
        private const string QUERYSTRING = "SELECT ROOM_TILE_GRID_X, ROOM_TILE_GRID_Y, IMAGE, CUTVIEW, DARKNESS, TRASPASSABLE FROM TILES " +
                "WHERE (ROOM_TILE_GRID_X BETWEEN @tilexo AND @tilexf) AND (ROOM_TILE_GRID_Y BETWEEN @tileyo AND @tileyf) " +
                "ORDER BY ROOM_TILE_GRID_Y, ROOM_TILE_GRID_X";

        public List<DBTile> dBTiles = new List<DBTile>();

        public ScreenTilesReader(): base()
        {
            GetScreenTilesThread = new Thread(ReadTiles);
        }

        public void GetScreenTiles(SqlConnection connection, SqlTransaction transaction, int xo, int yo, int xf, int yf)
        {
            readed = false;
            
            dBTiles.Clear();
            //At the end of the gameTick is called;
            //GC.Collect();

            SqlCommand command = new SqlCommand(QUERYSTRING, connection, transaction);

            command.Parameters.AddWithValue("@tilexo", xo);
            command.Parameters.AddWithValue("@tilexf", xf);
            command.Parameters.AddWithValue("@tileyo", yo);
            command.Parameters.AddWithValue("@tileyf", yf);

            try
            {
                TilesReader = command.ExecuteReader();
                //GetScreenTilesThread.Start();
                ReadTiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReadTiles()
        {
            try
            {
                //GODmESUREITOR.StartMesure();

                DBTile _local;
                while (TilesReader.Read())//Por row
                {
                    // Convertir los datos a elementos y meterlos en una lista, diccionario,... lo que se necesite, para la funcion que lo pinta
                    _local = new DBTile();
                    _local.X = (int)TilesReader[0];
                    _local.Y = (int)TilesReader[1];
                    _local.Image = (string)TilesReader[2];
                    _local.Cutview = Types.DBBoolToBoolean((string)TilesReader[3]);
                    _local.Darkness = (int)TilesReader[4];
                    _local.Traspassable = Types.DBBoolToBoolean((string)TilesReader[5]);

                    dBTiles.Add(_local);
                }
                
                TilesReader.Close();
                TilesReader = null;
                //At the end of GameTick is called
                //GC.Collect();
            }

            catch(Exception e)
            {

            }
            finally
            {
                try
                {
                    //GODmESUREITOR.StopMesure();
                    readed = true;

                    //Work after freeing processing frame
                    GetScreenTilesThread = new Thread(ReadTiles);                    
                }
                catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
            }
        }
    }
}
