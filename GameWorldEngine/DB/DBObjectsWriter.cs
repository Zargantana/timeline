using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class DBObjectsWriter
    {
        private const string RL_QUERYSTRING = "UPDATE [OBJECT_PARTS] SET [LIGHTSWITCH_STATUS] = @Status WHERE [UID] = @UID";
        public void WriteLightSwithcStatus(SqlConnection connection, SqlTransaction Transaction, string UID, bool switchStatus)
        {
            //Escribir los datos de Player para un move que empieza.
            SqlCommand command = new SqlCommand(RL_QUERYSTRING, connection, Transaction);
            command.Parameters.AddWithValue("@UID", UID);
            command.Parameters.AddWithValue("@Status", switchStatus?"true":"false");
            command.ExecuteNonQuery();
        }       
    }
}
