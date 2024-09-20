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
        private const string OP_QUERYSTRING = "SELECT [UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]" +
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
                        dBObjectPart.PV = (int)objectPartsReader[4];
                        dBObjectPart.Invulnerable = Types.DBBoolToBoolean((string)objectPartsReader[5]);
                        dBObjectPart.Cutview = Types.DBBoolToBoolean((string)objectPartsReader[6]);
                        dBObjectPart.Traspassable = Types.DBBoolToBoolean((string)objectPartsReader[7]);
                        dBObjectPart.LightStrength = (int)objectPartsReader[8];
                        dBObjectPart.LightTiles = (int)objectPartsReader[9];
                        dBObjectPart.LightFactor = Types.DBDoubleToDouble((string)objectPartsReader[10], 1.0f);
                        dBObjectPart.LightSwitch = Types.DBBoolToBoolean((string)objectPartsReader[11]);
                        dBObjectPart.LightSwitchStatus = Types.DBBoolToBoolean((string)objectPartsReader[12]);
                        dBObjectPart.Above  = Types.DBBoolToBoolean((string)objectPartsReader[13]);

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

        private const string OOP_QUERYSTRING = "SELECT [UID],[NAME],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]" +
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
                        dBObjectPart.PV = (int)objectPartsReader[2];
                        dBObjectPart.Invulnerable = Types.DBBoolToBoolean((string)objectPartsReader[3]);
                        dBObjectPart.Cutview = Types.DBBoolToBoolean((string)objectPartsReader[4]);
                        dBObjectPart.Traspassable = Types.DBBoolToBoolean((string)objectPartsReader[5]);
                        dBObjectPart.LightStrength = (int)objectPartsReader[6];
                        dBObjectPart.LightTiles = (int)objectPartsReader[7];
                        dBObjectPart.LightFactor = Types.DBDoubleToDouble((string)objectPartsReader[8], 1.0f);
                        dBObjectPart.LightSwitch = Types.DBBoolToBoolean((string)objectPartsReader[9]);
                        dBObjectPart.LightSwitchStatus = Types.DBBoolToBoolean((string)objectPartsReader[10]);
                        dBObjectPart.Above = Types.DBBoolToBoolean((string)objectPartsReader[11]);
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

        private const string OOP2_QUERYSTRING = "SELECT [UID],[NAME],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]" +
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
                        dBObjectPart.PV = (int)objectPartsReader[2];
                        dBObjectPart.Invulnerable = Types.DBBoolToBoolean((string)objectPartsReader[3]);
                        dBObjectPart.Cutview = Types.DBBoolToBoolean((string)objectPartsReader[4]);
                        dBObjectPart.Traspassable = Types.DBBoolToBoolean((string)objectPartsReader[5]);
                        dBObjectPart.LightStrength = (int)objectPartsReader[6];
                        dBObjectPart.LightTiles = (int)objectPartsReader[7];
                        dBObjectPart.LightFactor = Types.DBDoubleToDouble((string)objectPartsReader[8], 1.0f);
                        dBObjectPart.LightSwitch = Types.DBBoolToBoolean((string)objectPartsReader[9]);
                        dBObjectPart.LightSwitchStatus = Types.DBBoolToBoolean((string)objectPartsReader[10]);
                        dBObjectPart.Above = Types.DBBoolToBoolean((string)objectPartsReader[11]);
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
