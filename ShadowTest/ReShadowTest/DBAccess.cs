using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReShadowTest
{
    public class DBTile
    {
        private int world_x;
        private int world_y;

        public int WX { get { return world_x; } set { world_x = value; } }
        public int WY { get { return world_y; } set { world_y = value; } }

        public int CX(int ElementX)
        {
            return WorldToCalcCoords.X(world_x,ElementX);
        }

        public int CY(int ElementY)
        {
            return WorldToCalcCoords.Y(world_y, ElementY);
        }

        public int SX(int refX)
        {
            return WorldToScreenCoords.X(world_x, refX);
        }

        public int SY(int refY)
        {
            return WorldToScreenCoords.Y(world_y, refY);
        }
    }

    public class WorldToCalcCoords
    {
        public static int X(int WPointX, int WcenterX)
        {
            return WPointX - WcenterX;
        }

        public static int Y(int WPointY, int WcenterY)
        {
            return 0 - (WPointY - WcenterY);
        }
    }

    public class WorldToScreenCoords
    {
        public static int X(int WPointX, int WrefX)
        {
            return WPointX - WrefX;
        }

        public static int Y(int WPointY, int WrefY)
        {
            return WPointY - WrefY;
        }
    }

    public class CalcToScreenCoords
    {
        public static int X(int CPointX, int WcenterX, int WrefX)
        {
            return WorldToScreenCoords.X(CalcToWoorldCoords.X(CPointX, WcenterX),  WrefX);
        }

        public static int Y(int CPointY, int WcenterY, int WrefY)
        {
            return WorldToScreenCoords.Y(CalcToWoorldCoords.Y(CPointY, WcenterY), WrefY);
        }
    }    

    public class CalcToWoorldCoords
    {
        public static int X(int CPointX, int WcenterX)
        {
            return CPointX + WcenterX;
        }

        public static int Y(int CPointY, int WcenterY)
        {
            return (0 - CPointY) + WcenterY;
        }
    }

    public class ScreenToCalcCoords
    {
        public static int X(int SPointX, int WcenterX, int WrefX)
        {
            return WorldToCalcCoords.X(ScreenToWorldCoords.X(SPointX, WrefX), WcenterX);
        }

        public static int Y(int SPointY, int WcenterY, int WrefY)
        {
            return WorldToCalcCoords.Y(ScreenToWorldCoords.Y(SPointY, WrefY), WcenterY);
        }
    }

    public class ScreenToWorldCoords
    {
        public static int X(int SPointX, int WrefX)
        {
            return SPointX + WrefX;
        }

        public static int Y(int SPointY, int WrefY)
        {
            return SPointY + WrefY;
        }
    }

    public class DBAccess
    {
        private const string QUERYSTRING = "SELECT ROOM_TILE_GRID_X, ROOM_TILE_GRID_Y FROM TILES " +
            "WHERE (ROOM_TILE_GRID_X BETWEEN @tilexo AND @tilexf) AND (ROOM_TILE_GRID_Y BETWEEN @tileyo AND @tileyf) AND CUTVIEW = 'true' " +
            "ORDER BY ROOM_TILE_GRID_Y, ROOM_TILE_GRID_X";
        public static List<DBTile> GetScreenTiles(int xo, int yo, int xf, int yf)
        {
            SqlDataReader TilesReader;
            SqlConnection connection;
            List<DBTile> Result = new List<DBTile>();

            connection = new SqlConnection("data source = (local)\\SQLEXPRESS2K14; initial catalog = TimeMachine; Integrated Security = true;");
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(QUERYSTRING, connection);

                command.Parameters.AddWithValue("@tilexo", xo);
                command.Parameters.AddWithValue("@tilexf", xf);
                command.Parameters.AddWithValue("@tileyo", yo);
                command.Parameters.AddWithValue("@tileyf", yf);

                TilesReader = command.ExecuteReader();
                try
                {
                    DBTile A;
                    while (TilesReader.Read())//Por row
                    {
                        A = new DBTile();
                        A.WX = (int)TilesReader[0];
                        A.WY = (int)TilesReader[1];
                        Result.Add(A);
                    }
                }
                catch (Exception e1)
                {

                }
                finally
                {
                    TilesReader.Close();
                    TilesReader = null;
                    
                }
            }
            catch (Exception e2)
            {

            }
            finally
            {
                connection.Close();
                connection = null;
                GC.Collect();
            }
            return Result;
        }
    }
}
