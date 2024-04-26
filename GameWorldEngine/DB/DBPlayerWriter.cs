using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class DBPlayerWriter
    {
        private const string WM_QUERYSTRING = "UPDATE PLAYERS SET FACING = @Facing, MOVEMENT = @Movement, MOVEMENT_TIMESTAMP = @Movement_Timestamp, MOVED = 'false' WHERE UID = @PlayerUID";
        public void WriteMove(string PlayerUID, int Movement, DateTime Movement_Timestamp, SqlConnection connection, SqlTransaction Transaction)
        {
            //Escribir los datos de Player para un move que empieza.
            SqlCommand command = new SqlCommand(WM_QUERYSTRING, connection, Transaction);
            command.Parameters.AddWithValue("@Facing", Movement);
            command.Parameters.AddWithValue("@Movement", Movement);
            command.Parameters.AddWithValue("@Movement_Timestamp", Movement_Timestamp);
            command.Parameters.AddWithValue("@PlayerUID", PlayerUID);
            command.ExecuteNonQuery();
        }

        private const string WF_QUERYSTRING = "UPDATE PLAYERS SET FACING = @Facing, FACING_TIMESTAMP = @Facing_Timestamp WHERE UID = @PlayerUID";
        public void WriteFace(string PlayerUID, int Facing, DateTime Facing_Timestamp, SqlConnection connection, SqlTransaction Transaction)
        {
            try
            {
                //Escribir los datos de Player para reencararlo.
                SqlCommand command = new SqlCommand(WF_QUERYSTRING, connection, Transaction);
                command.Parameters.AddWithValue("@PlayerUID", PlayerUID);
                command.Parameters.AddWithValue("@Facing_Timestamp", Facing_Timestamp);
                command.Parameters.AddWithValue("@Facing", Facing);
                command.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

            }
        }

        private const string WI_QUERYSTRING = "UPDATE PLAYERS SET [INTERACT_TIMESTAMP] = @Interact_Timestamp WHERE UID = @PlayerUID";
        public void WriteInteract(string PlayerUID, DateTime Interaction_Timestamp, SqlConnection connection, SqlTransaction Transaction)
        {
            try
            {
                //Escribir los datos de Player para saber el momento de la ultima interaccion.
                SqlCommand command = new SqlCommand(WI_QUERYSTRING, connection, Transaction);
                command.Parameters.AddWithValue("@PlayerUID", PlayerUID);
                command.Parameters.AddWithValue("@Interact_Timestamp", Interaction_Timestamp);
                command.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

            }
        }

        private const string MSN_QUERYSTRING = "UPDATE PLAYERS SET ROOM_TILE_GRID_Y = ROOM_TILE_GRID_Y - 1, MOVED = 'true' WHERE UID = @PlayerUID";
        public void WriteMoveNorthStep(SqlConnection connection, SqlTransaction Transaction, string PlayerUID)
        {
            WriteMoveStep(connection, Transaction, MSN_QUERYSTRING, PlayerUID);
        }

        private const string MSE_QUERYSTRING = "UPDATE PLAYERS SET ROOM_TILE_GRID_X = ROOM_TILE_GRID_X + 1, MOVED = 'true' WHERE UID = @PlayerUID";
        public void WriteMoveEastStep(SqlConnection connection, SqlTransaction Transaction, string PlayerUID)
        {
            WriteMoveStep(connection, Transaction, MSE_QUERYSTRING, PlayerUID);
        }
        private const string MSS_QUERYSTRING = "UPDATE PLAYERS SET ROOM_TILE_GRID_Y = ROOM_TILE_GRID_Y + 1, MOVED = 'true' WHERE UID = @PlayerUID";
        public void WriteMoveSouthStep(SqlConnection connection, SqlTransaction Transaction, string PlayerUID)
        {
            WriteMoveStep(connection, Transaction, MSS_QUERYSTRING, PlayerUID);
        }
        private const string MSW_QUERYSTRING = "UPDATE PLAYERS SET ROOM_TILE_GRID_X = ROOM_TILE_GRID_X - 1, MOVED = 'true' WHERE UID = @PlayerUID";
        public void WriteMoveWestStep(SqlConnection connection, SqlTransaction Transaction, string PlayerUID)
        {
            WriteMoveStep(connection, Transaction, MSW_QUERYSTRING, PlayerUID);
        }

        private void WriteMoveStep(SqlConnection connection, SqlTransaction Transaction, string QueryString, string PlayerUID)
        {
            try
            {
                //Escribir los datos de Player para reencararlo.
                SqlCommand command = new SqlCommand(QueryString, connection, Transaction);
                command.Parameters.AddWithValue("@PlayerUID", PlayerUID);
                command.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

            }
        }

        private const string ME_QUERYSTRING = "UPDATE PLAYERS SET MOVEMENT = 0 WHERE UID = @PlayerUID";
        public void WriteMoveEnd(SqlConnection connection, SqlTransaction Transaction, string PlayerUID)
        {
            try
            {
                //Escribir los datos de Player para reencararlo.
                SqlCommand command = new SqlCommand(ME_QUERYSTRING, connection, Transaction);
                command.Parameters.AddWithValue("@PlayerUID", PlayerUID);
                command.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
