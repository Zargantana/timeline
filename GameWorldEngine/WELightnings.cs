using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class WELightnings
    {
        public void ResetLights(SqlConnection connection, SqlTransaction Transaction)
        {
            (new DBTileWriter()).ResetLightnings(connection, Transaction);
        }


        public void PlayersLights(DBPlayer[] InitiativePlayerList, SqlConnection connection, SqlTransaction Transaction)
        {
            /*
            foreach (DBPlayer dBPlayer in InitiativePlayerList)
            {
                //(new DBTileWriter()).SquareLightning(dBPlayer.Tile_X, dBPlayer.Tile_Y, 3, 100, connection, Transaction);
                (new DBTileWriter()).SquareLightning(dBPlayer.Tile_X, dBPlayer.Tile_Y, dBPlayer.LightTiles, dBPlayer.LightStrength, dBPlayer.LightFactor, connection, Transaction);

            }
            */
        }

        public void PlayersLightsV2(DBPlayer[] InitiativePlayerList, SqlConnection connection, SqlTransaction Transaction)
        {
            /*
            foreach (DBPlayer dBPlayer in InitiativePlayerList)
            {
                (new DBTileWriter()).OneLightning(dBPlayer.Tile_X, dBPlayer.Tile_Y, dBPlayer.LightStrength, connection, Transaction);

                SLine(dBPlayer.Tile_X, dBPlayer.Tile_Y - 1, 0, -1, dBPlayer.LightTiles - 1, dBPlayer.LightFactor, 
                    (int)Math.Floor((double)dBPlayer.LightStrength * dBPlayer.LightFactor), connection, Transaction,0);
                SLine(dBPlayer.Tile_X + 1, dBPlayer.Tile_Y, 1, 0, dBPlayer.LightTiles - 1, dBPlayer.LightFactor, 
                    (int)Math.Floor((double)dBPlayer.LightStrength * dBPlayer.LightFactor), connection, Transaction,0);
                SLine(dBPlayer.Tile_X, dBPlayer.Tile_Y + 1, 0, 1, dBPlayer.LightTiles - 1, dBPlayer.LightFactor, 
                    (int)Math.Floor((double)dBPlayer.LightStrength * dBPlayer.LightFactor), connection, Transaction,0);
                SLine(dBPlayer.Tile_X - 1, dBPlayer.Tile_Y, -1, 0, dBPlayer.LightTiles - 1, dBPlayer.LightFactor, 
                    (int)Math.Floor((double)dBPlayer.LightStrength * dBPlayer.LightFactor), connection, Transaction,0);

                Diagonal(dBPlayer.Tile_X + 1, dBPlayer.Tile_Y - 1, 1, -1, dBPlayer.LightTiles - 1, dBPlayer.LightFactor, 
                    (int)Math.Floor((double)dBPlayer.LightStrength * dBPlayer.LightFactor), connection, Transaction);
                Diagonal(dBPlayer.Tile_X + 1, dBPlayer.Tile_Y + 1, 1, 1, dBPlayer.LightTiles - 1, dBPlayer.LightFactor, 
                    (int)Math.Floor((double)dBPlayer.LightStrength * dBPlayer.LightFactor), connection, Transaction);
                Diagonal(dBPlayer.Tile_X - 1, dBPlayer.Tile_Y + 1, -1, 1, dBPlayer.LightTiles - 1, dBPlayer.LightFactor, 
                    (int)Math.Floor((double)dBPlayer.LightStrength * dBPlayer.LightFactor), connection, Transaction);
                Diagonal(dBPlayer.Tile_X - 1, dBPlayer.Tile_Y - 1, -1, -1, dBPlayer.LightTiles - 1, dBPlayer.LightFactor, 
                    (int)Math.Floor((double)dBPlayer.LightStrength * dBPlayer.LightFactor), connection, Transaction);
            }
            */
        }

        private void Line(int X, int Y, int vel_X, int vel_Y, int TTL, double Factor, int Strength, SqlConnection connection, SqlTransaction Transaction)
        {
            (new DBTileWriter()).OneLightning(X, Y, Strength, connection, Transaction);
            //If no cutview
            if (TTL > 0) 
            {
                if ((new DBViewElements()).CutviewPositionCheck(connection, Transaction, X, Y))
                {
                    if (vel_X == 0) //Vertical
                    {
                        SLine(X, Y + vel_Y, 0, vel_Y, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction,0);
                        SLine(X - 1, Y + vel_Y, 0, 0, 0, 0.0f, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction,0);
                        SLine(X + 1, Y + vel_Y, 0, 0, 0, 0.0f, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction,0);
                    }
                    else //Horizontal
                    {
                        SLine(X + vel_X, Y, vel_X, 0, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction,0);
                        SLine(X + vel_X, Y - 1, 0, 0, 0, 0.0f, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction,0);
                        SLine(X + vel_X, Y + 1, 0, 0, 0, 0.0f, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction,0);
                    }
                }
            }
        }

        private void SLine(int X, int Y, int vel_X, int vel_Y, int TTL, double Factor, int Strength, SqlConnection connection, SqlTransaction Transaction, int Generation)
        {
            (new DBTileWriter()).OneLightning(X, Y, Strength, connection, Transaction);
            //If no cutview
            if (TTL > 0)
            {
                if ((new DBViewElements()).CutviewPositionCheck(connection, Transaction, X, Y))
                {
                    if (vel_X == 0) //Vertical
                    {
                        if (Generation == 2) Line(X, Y + vel_Y, 0, vel_Y, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor), connection, Transaction);
                        else SLine(X, Y + vel_Y, 0, vel_Y, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor), connection, Transaction, Generation++);
                    }
                    else //Horizontal
                    {
                        if (Generation == 2) Line(X + vel_X, Y, vel_X, 0, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor), connection, Transaction);
                        else SLine(X + vel_X, Y, vel_X, 0, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor), connection, Transaction, Generation++);
                    }
                }
            }
        }

        private void Diagonal(int X, int Y, int vel_X, int vel_Y, int TTL, double Factor, int Strength, SqlConnection connection, SqlTransaction Transaction)
        {
            (new DBTileWriter()).OneLightning(X, Y, Strength, connection, Transaction);
            //If no cutview
            if (TTL > 0)
            {
                if ((new DBViewElements()).CutviewPositionCheck(connection, Transaction, X, Y))
                {
                    Diagonal(X + vel_X, Y + vel_Y, vel_X, vel_Y, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction);
                    SLine(X + vel_X, Y, vel_X, 0, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction, 0);
                    SLine(X, Y + vel_Y, 0, vel_Y, TTL - 1, Factor, (int)Math.Floor((double)Strength * Factor * Factor), connection, Transaction, 0);
                }
            }
        }

        public void ObjectPartsLights(DBObjectPart[] LightObjectParts, SqlConnection connection, SqlTransaction Transaction)
        {
            foreach (DBObjectPart dBObjectPart in LightObjectParts)
            {
                //(new DBTileWriter()).SquareLightning(dBPlayer.Tile_X, dBPlayer.Tile_Y, 3, 100, connection, Transaction);
                if (dBObjectPart.LightSwitchStatus)
                    (new DBTileWriter()).SquareLightning(dBObjectPart.X, dBObjectPart.Y, dBObjectPart.LightTiles, dBObjectPart.LightStrength, dBObjectPart.LightFactor, connection, Transaction);
            }
        }

    }
}
