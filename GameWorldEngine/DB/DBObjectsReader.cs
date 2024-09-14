using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseTypes;

namespace TimeFabric
{
    public class DBObjectsReader
    {
        public const int MAX_ROOM_OBJECTS = 128;
        private const string OP_QUERYSTRING = "SELECT [UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]" +
            ",[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS], [ABOVE] FROM [dbo].[OBJECT_PARTS]";
        public DBObjectPartList ReadObjectPartsList(SqlConnection connection, SqlTransaction Transaction, out DBObjectPart[] LightSwitchObjectParts)
        {
            DBObjectPartList dBObjectPartsList = new DBObjectPartList();
            LightSwitchObjectParts = new DBObjectPart[MAX_ROOM_OBJECTS];

            //Read from DB.
            SqlCommand command = new SqlCommand(OP_QUERYSTRING, connection, Transaction);
            try
            {
                SqlDataReader objectPartsReader = command.ExecuteReader();
                try
                {
                    DBObjectPart dBObjectPart;

                    int count = 0;
                    while (objectPartsReader.Read())//Por row
                    {
                        dBObjectPart = new DBObjectPart();

                        dBObjectPart.UID = ((Guid)objectPartsReader[0]).ToString();
                        dBObjectPart.Name = (string)objectPartsReader[1];
                        dBObjectPart.X = (int)objectPartsReader[2];
                        dBObjectPart.Y = (int)objectPartsReader[3];
                        dBObjectPart.Image =(string)objectPartsReader[4];
                        dBObjectPart.PV = (int)objectPartsReader[5];
                        dBObjectPart.Invulnerable = Types.DBBoolToBoolean((string)objectPartsReader[6]);
                        dBObjectPart.Cutview = Types.DBBoolToBoolean((string)objectPartsReader[7]);
                        dBObjectPart.Traspassable = Types.DBBoolToBoolean((string)objectPartsReader[8]);
                        dBObjectPart.LightStrength = (int)objectPartsReader[9];
                        dBObjectPart.LightTiles = (int)objectPartsReader[10];
                        dBObjectPart.LightFactor = Types.DBDoubleToDouble((string)objectPartsReader[11], 1.0f);
                        dBObjectPart.LightSwitch = Types.DBBoolToBoolean((string)objectPartsReader[12]);
                        dBObjectPart.LightSwitchStatus = Types.DBBoolToBoolean((string)objectPartsReader[13]);
                        dBObjectPart.Above  = Types.DBBoolToBoolean((string)objectPartsReader[14]);

                        dBObjectPartsList.Add(dBObjectPart.UID, dBObjectPart);
                        LightSwitchObjectParts[count++] = dBObjectPart;
                    }
                    Array.Resize<DBObjectPart>(ref LightSwitchObjectParts, count);
                }
                finally
                {
                    try
                    {
                        objectPartsReader.Close();
                        objectPartsReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dBObjectPartsList;
        }

        private const string OOP_QUERYSTRING = "SELECT [UID],[NAME],[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]" +
           ",[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[LIGHTSWITCH_STATUS],[ABOVE] FROM [dbo].[OBJECT_PARTS] WHERE [ROOM_TILE_GRID_X]=@X AND [ROOM_TILE_GRID_Y]=@Y";
        public DBObjectPart ReadObjectPart(SqlConnection connection, SqlTransaction Transaction, int X, int Y)
        {
            DBObjectPart dBObjectPart = null;

            //Read from DB.
            SqlCommand command = new SqlCommand(OOP_QUERYSTRING, connection, Transaction);
            command.Parameters.AddWithValue("@X", X);
            command.Parameters.AddWithValue("@Y", Y);
            try
            {
                SqlDataReader objectPartsReader = command.ExecuteReader();
                try
                {
                    

                    if (objectPartsReader.Read())//Por row
                    {
                        dBObjectPart = new DBObjectPart();

                        dBObjectPart.UID = ((Guid)objectPartsReader[0]).ToString();
                        dBObjectPart.Name = (string)objectPartsReader[1];
                        dBObjectPart.Image = (string)objectPartsReader[2];
                        dBObjectPart.PV = (int)objectPartsReader[3];
                        dBObjectPart.Invulnerable = Types.DBBoolToBoolean((string)objectPartsReader[4]);
                        dBObjectPart.Cutview = Types.DBBoolToBoolean((string)objectPartsReader[5]);
                        dBObjectPart.Traspassable = Types.DBBoolToBoolean((string)objectPartsReader[6]);
                        dBObjectPart.LightStrength = (int)objectPartsReader[7];
                        dBObjectPart.LightTiles = (int)objectPartsReader[8];
                        dBObjectPart.LightFactor = Types.DBDoubleToDouble((string)objectPartsReader[9], 1.0f);
                        dBObjectPart.LightSwitch = Types.DBBoolToBoolean((string)objectPartsReader[10]);
                        dBObjectPart.LightSwitchStatus = Types.DBBoolToBoolean((string)objectPartsReader[11]);
                        dBObjectPart.Above = Types.DBBoolToBoolean((string)objectPartsReader[12]);
                    }
                }
                finally
                {
                    try
                    {
                        objectPartsReader.Close();
                        objectPartsReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dBObjectPart;
        }

        private const string OOP2_QUERYSTRING = "SELECT [UID],[NAME],[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]" +
           ",[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[LIGHTSWITCH_STATUS],[ABOVE] FROM [dbo].[OBJECT_PARTS] WHERE [ROOM_TILE_GRID_X]=@X AND [ROOM_TILE_GRID_Y]=@Y AND [ABOVE]='false'";
        public DBObjectPart ReadFloorObjectPart(SqlConnection connection, SqlTransaction Transaction, int X, int Y)
        {
            DBObjectPart dBObjectPart = null;

            //Read from DB.
            SqlCommand command = new SqlCommand(OOP2_QUERYSTRING, connection, Transaction);
            command.Parameters.AddWithValue("@X", X);
            command.Parameters.AddWithValue("@Y", Y);
            try
            {
                SqlDataReader objectPartsReader = command.ExecuteReader();
                try
                {


                    if (objectPartsReader.Read())//Por row
                    {
                        dBObjectPart = new DBObjectPart();

                        dBObjectPart.UID = ((Guid)objectPartsReader[0]).ToString();
                        dBObjectPart.Name = (string)objectPartsReader[1];
                        dBObjectPart.Image = (string)objectPartsReader[2];
                        dBObjectPart.PV = (int)objectPartsReader[3];
                        dBObjectPart.Invulnerable = Types.DBBoolToBoolean((string)objectPartsReader[4]);
                        dBObjectPart.Cutview = Types.DBBoolToBoolean((string)objectPartsReader[5]);
                        dBObjectPart.Traspassable = Types.DBBoolToBoolean((string)objectPartsReader[6]);
                        dBObjectPart.LightStrength = (int)objectPartsReader[7];
                        dBObjectPart.LightTiles = (int)objectPartsReader[8];
                        dBObjectPart.LightFactor = Types.DBDoubleToDouble((string)objectPartsReader[9], 1.0f);
                        dBObjectPart.LightSwitch = Types.DBBoolToBoolean((string)objectPartsReader[10]);
                        dBObjectPart.LightSwitchStatus = Types.DBBoolToBoolean((string)objectPartsReader[11]);
                        dBObjectPart.Above = Types.DBBoolToBoolean((string)objectPartsReader[12]);
                    }
                }
                finally
                {
                    try
                    {
                        objectPartsReader.Close();
                        objectPartsReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dBObjectPart;
        }


    }
}
