using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class DBViewElements
    {
        private const string OOP_QUERYSTRING = "SELECT UID FROM TILES WHERE ROOM_TILE_GRID_X = @X AND ROOM_TILE_GRID_Y = @Y AND CUTVIEW = 'true' " +
            "UNION SELECT UID FROM OBJECT_PARTS WHERE ROOM_TILE_GRID_X = @X AND ROOM_TILE_GRID_Y = @Y AND CUTVIEW = 'true'";
        public bool CutviewPositionCheck(SqlConnection connection, SqlTransaction Transaction, int X, int Y)
        {
            bool bResult = true;

            //Read from DB.
            SqlCommand command = new SqlCommand(OOP_QUERYSTRING, connection, Transaction);
            command.Parameters.AddWithValue("@X", X);
            command.Parameters.AddWithValue("@Y", Y);
            try
            {
                SqlDataReader objectPartsReader = command.ExecuteReader();
                try
                {
                    bResult = !objectPartsReader.Read();
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

            return bResult;
        }
    }
}
