using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class WETurnKeeper
    {
        public void HacerLaRonda(DBPlayer[] InitiativePlayerList, SqlConnection connection, SqlTransaction Transaction)
        {
            //TODO: Conecta a BD y empieza a resolver lo dle papel por orden de iniciativas.
            //Por ahora:
            // *      (CURRENTDATE - [MOVEMENT_TIMESTAMP]) >= (MOVEMENT_SPEED/2)
             //*      (CURRENTDATE - [MOVEMENT_TIMESTAMP]) >= (MOVEMENT_SPEED)
            // Por cada PJ (en orden de iniciativa) que esté en:
            foreach (DBPlayer dBPlayer in InitiativePlayerList)
            {
                int PlayerSepeedMillis = int.MaxValue;
                try
                {
                    PlayerSepeedMillis = (int)Math.Floor(dBPlayer.PlayerMoveSpeed * 1000.0f);
                }
                catch { }

                //MOVEMENT != 0
                if (dBPlayer.Movement != 0)
                {
                    if (dBPlayer.Moved)
                    {
                        if ((DateTime.Now - dBPlayer.MovementStart) >= new TimeSpan(0, 0, 0, 0, PlayerSepeedMillis))
                        {
                            //Terminar el movimiento en BD.
                            (new DBPlayerWriter()).WriteMoveEnd(connection, Transaction, dBPlayer.UID);
                        }
                    }
                    else
                    {
                        if ((DateTime.Now - dBPlayer.MovementStart) >= new TimeSpan(0, 0, 0, 0, PlayerSepeedMillis/2))
                        {
                            int Tile_X = 0, Tile_Y = 0;
                            switch (dBPlayer.Movement)
                            {
                                case 1:
                                    {
                                        Tile_X = dBPlayer.Tile_X;
                                        Tile_Y = dBPlayer.Tile_Y - 1;
                                        break;
                                    }
                                case 2:
                                    {
                                        Tile_X = dBPlayer.Tile_X + 1;
                                        Tile_Y = dBPlayer.Tile_Y;
                                        break;
                                    }
                                case 3:
                                    {
                                        Tile_X = dBPlayer.Tile_X;
                                        Tile_Y = dBPlayer.Tile_Y + 1;
                                        break;
                                    }
                                case 4:
                                    {
                                        Tile_X = dBPlayer.Tile_X - 1;
                                        Tile_Y = dBPlayer.Tile_Y;
                                        break;
                                    }
                            }
                            if ((new DBPlayerReader()).ReadCanMove(connection, Transaction, Tile_X, Tile_Y))
                            {
                                switch (dBPlayer.Movement)
                                {
                                    case 1:
                                        {
                                            (new DBPlayerWriter()).WriteMoveNorthStep(connection, Transaction, dBPlayer.UID);
                                            break;
                                        }
                                    case 2:
                                        {
                                            (new DBPlayerWriter()).WriteMoveEastStep(connection, Transaction, dBPlayer.UID);
                                            break;
                                        }
                                    case 3:
                                        {
                                            (new DBPlayerWriter()).WriteMoveSouthStep(connection, Transaction, dBPlayer.UID);
                                            break;
                                        }
                                    case 4:
                                        {
                                            (new DBPlayerWriter()).WriteMoveWestStep(connection, Transaction, dBPlayer.UID);
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                //Terminar el movimiento en BD.
                                (new DBPlayerWriter()).WriteMoveEnd(connection, Transaction, dBPlayer.UID);
                            }
                        }

                    }
                }
            }
            
            
        }
    }
}
