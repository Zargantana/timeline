using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class DBTileWriter
    {
        private const string RL_QUERYSTRING = "UPDATE T SET T.DARKNESS = B.DARKNESS FROM TILES T INNER JOIN TILE_TYPES B ON (B.UID = T.TYPE_DEFINITION)";
        public void ResetLightnings(SqlConnection connection, SqlTransaction Transaction)
        {
            //Escribir los datos de Player para un move que empieza.
            SqlCommand command = new SqlCommand(RL_QUERYSTRING, connection, Transaction);
            command.ExecuteNonQuery();
        }

        /*
         --AREA
  UPDATE TILES SET DARKNESS = CASE WHEN (DARKNESS - 12) > 0 THEN (DARKNESS - 12) ELSE 0 END WHERE (ROOM_TILE_GRID_X BETWEEN 1 AND 9) AND (ROOM_TILE_GRID_Y BETWEEN 1 AND 9)
  UPDATE TILES SET DARKNESS = DARKNESS - 25 WHERE (ROOM_TILE_GRID_X BETWEEN 2 AND 8) AND (ROOM_TILE_GRID_Y BETWEEN 2 AND 8)
  UPDATE TILES SET DARKNESS = DARKNESS - 50 WHERE (ROOM_TILE_GRID_X BETWEEN 3 AND 7) AND (ROOM_TILE_GRID_Y BETWEEN 3 AND 7)
  UPDATE TILES SET DARKNESS = DARKNESS - 100 WHERE (ROOM_TILE_GRID_X BETWEEN 4 AND 6) AND (ROOM_TILE_GRID_Y BETWEEN 4 AND 6)
         */

        private const string SL_QUERYSTRING = "UPDATE TILES SET DARKNESS = CASE WHEN (DARKNESS - @Lighten) > 0 THEN (DARKNESS - @Lighten) ELSE 0 END WHERE (ROOM_TILE_GRID_X BETWEEN @origin_x AND @end_x) AND (ROOM_TILE_GRID_Y BETWEEN @origin_y AND @end_y)";
        public void SquareLightning(int PlayerX, int PlayerY, int LingningSquares, int LightningStrength, double LightningFactor, SqlConnection connection, SqlTransaction Transaction)
        {
            //Escribir los datos de Player para un move que empieza.
            for (int i = 1; i <= LingningSquares; i++)
            {
                using (SqlCommand command = new SqlCommand(SL_QUERYSTRING, connection, Transaction))
                {
                    command.Parameters.AddWithValue("@Lighten", LightningStrength);
                    command.Parameters.AddWithValue("@origin_x", PlayerX - i);
                    command.Parameters.AddWithValue("@end_x", PlayerX + i);
                    command.Parameters.AddWithValue("@origin_y", PlayerY - i);
                    command.Parameters.AddWithValue("@end_y", PlayerY + i);
                    int j = command.ExecuteNonQuery();

                    LightningStrength = (int)Math.Floor((double)LightningStrength * LightningFactor); 
                }
            }
        }
        
        private const string OL_QUERYSTRING = "UPDATE TILES SET DARKNESS = CASE WHEN (DARKNESS - @Lighten) > 0 THEN (DARKNESS - @Lighten) ELSE 0 END WHERE (ROOM_TILE_GRID_X = @x) AND (ROOM_TILE_GRID_Y = @y)";
        public void OneLightning(int PlayerX, int PlayerY, int LightningStrength, SqlConnection connection, SqlTransaction Transaction)
        {
            //Escribir los datos de Player para un move que empieza.
            using (SqlCommand command = new SqlCommand(OL_QUERYSTRING, connection, Transaction))
            {
                command.Parameters.AddWithValue("@Lighten", LightningStrength);
                command.Parameters.AddWithValue("@x", PlayerX);
                command.Parameters.AddWithValue("@y", PlayerY);
                command.ExecuteNonQuery();
            }
        }
    }
}
