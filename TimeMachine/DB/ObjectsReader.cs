﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using TimeMachine.DB.Model;
using DataBaseTypes;
using System.Drawing;

namespace TimeMachine.DB
{
    public class ObjectsReader: TWorker
    {
        private Thread GetNearbyObjectsThread;
        private SqlDataReader ObjectReader;
        private const string QUERYSTRING = "SELECT ROOM_TILE_GRID_X, ROOM_TILE_GRID_Y, CUTVIEW, TRASPASSABLE, ABOVE, ANIMATION, " + 
                "ANIMATION_LIGHT_ON, ANIMATION_SPEED, ANIMATION_TIMESTAMP, " +
                "LIGHTSWITCH, LIGHTSWITCH_STATUS FROM OBJECT_PARTS " +
                "WHERE (ROOM_TILE_GRID_X BETWEEN @tilexo AND @tilexf) AND (ROOM_TILE_GRID_Y BETWEEN @tileyo AND @tileyf) " +
                "ORDER BY ROOM_TILE_GRID_Y, ROOM_TILE_GRID_X";

        public List<DBObject> dBObjects = new List<DBObject>();

        public ObjectsReader(): base()
        {
            GetNearbyObjectsThread = new Thread(ReadNearbyObjects);
        }        

        public void GetNearbyObjects(SqlConnection connection, SqlTransaction transaction, int xo, int yo, int xf, int yf)
        {
            readed = false;
            
            dBObjects.Clear();
            //At the end of the gameTick is called;
            //GC.Collect();

            SqlCommand command = new SqlCommand(QUERYSTRING, connection, transaction);

            command.Parameters.AddWithValue("@tilexo", xo);
            command.Parameters.AddWithValue("@tilexf", xf);
            command.Parameters.AddWithValue("@tileyo", yo);
            command.Parameters.AddWithValue("@tileyf", yf);

            try
            {
                ObjectReader = command.ExecuteReader();
                //GetNearbyObjectsThread.Start();
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

                DBObject _local;
                while (ObjectReader.Read())//Por row
                {
                    // Convertir los datos a elementos y meterlos en una lista, diccionario,... lo que se necesite, para la funcion que lo pinta
                    _local = new DBObject();
                    _local.X = (int)ObjectReader[0];
                    _local.Y = (int)ObjectReader[1];
                    _local.Cutview = Types.DBBoolToBoolean((string)ObjectReader[2]);
                    _local.Traspassable = Types.DBBoolToBoolean((string)ObjectReader[3]);
                    _local.Above = Types.DBBoolToBoolean((string)ObjectReader[4]);
                    _local.Animation = ((Guid)ObjectReader[5]).ToString();
                    _local.Animation_light_on = ((Guid)ObjectReader[6]).ToString();
                    _local.Animation_speed = Types.DBDoubleToDouble((string)ObjectReader[7], 1.0f);
                    _local.Animation_timestamp = (DateTime)ObjectReader[8];
                    _local.Lightswitch = Types.DBBoolToBoolean((string)ObjectReader[9]);
                    _local.Lightswitch_status = Types.DBBoolToBoolean((string)ObjectReader[10]);

                    dBObjects.Add(_local);
                }
                
                ObjectReader.Close();
                ObjectReader = null;
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
                    GetNearbyObjectsThread = new Thread(ReadNearbyObjects);                    
                }
                catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
            }
        }
    }
}
