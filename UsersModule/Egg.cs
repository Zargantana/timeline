using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineNET.Models;
using System.Data;
using System.Data.SqlClient;

namespace TimeLineNET.GodZillaNest
{
    public class Egg
    {
        public const string MASTER_CONNECTIONSTRING = "data source=(local)\\SQLEXPRESS2K14;initial catalog=TheVoid;Integrated Security=true;";

        private string connectionString = MASTER_CONNECTIONSTRING;
        private SqlConnection connection;


        public Egg()
        {
            
        }

        public WorldModelEx PutIt(LoginModel credentials)
        {
            WorldModelEx startUp = new WorldModelEx();
            
            //Generate a GUID.
            startUp.PlayerToken = Guid.NewGuid().ToString();
            
            //Do DB validation of credentials.
            if (ValidateCredentials(credentials))
            {
                //Delete old guid from current user from world.
                DeleteOldTraces(credentials);//Credentials refere to a valid user.
                //Save GUID in loguedinUsers with world and startup position.
                LoginUser(credentials, startUp);
            }
            else
            {
                //Save GUID in loguedinUsers with PHANTOM world and random startup position.
                startUp.WorldName = "PHANTOM";
                startUp.X = (new Random()).Next(1,9);
                startUp.Y = (new Random()).Next(1, 9);
                LoginUser(credentials, startUp);
            }
            return startUp;
        }


        private bool ValidateCredentials(LoginModel credentials)
        {
            //TODO
            return credentials.PlayerName == credentials.PlayerPass;
        }
            
        private void DeleteOldTraces(LoginModel credentials)
        {
            //TODO
        }
            
        private void LoginUser(LoginModel credentials, WorldModelEx startUp)
        {
            //TODO
            startUp.WorldName = "World1";
            if (credentials.PlayerName == "Player1") startUp.PlayerToken = "e8b6d65a-aa79-4c7a-8c07-f8b064f60d74";
            else if (credentials.PlayerName == "Player2") startUp.PlayerToken = "8b0224d8-4f1b-4742-a282-a38c50b001d9"; 
            startUp.X = 5;
            startUp.Y = 5;
        }

        /*
        private void dooo()
        { 
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction sqlTransaction;

            StartReadingPlayerInfo(out sqlTransaction);

            try
            {
                //No le paso la conneciton aqui, porque si la he de resetear, mejor que no tenga que volver a crear todo... 
                //Total, pasar un puntero no ha de tardar tanto.
                GetPlayerData(sqlTransaction);

                //End transaction
                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
            }
        }

        private void StartReadingPlayerInfo(out SqlTransaction sqlTransaction)
        {
            sqlTransaction = connection.BeginTransaction(IsolationLevel.Snapshot);
        }

        private static readonly string QUERYSTRING = "";
        private void GetPlayerData(SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(QUERYSTRING, connection, transaction);
            command.Parameters.AddWithValue("@player", player);

            try
            {
                PlayerInfoReader = command.ExecuteReader();
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
                if (PlayerInfoReader.Read())
                {
                    PlayerInformation = new TMInformation();
                    PlayerInformation.North = (string)PlayerInfoReader[0];
                    PlayerInformation.South = (string)PlayerInfoReader[1];
                    PlayerInformation.West = (string)PlayerInfoReader[2];
                    PlayerInformation.East = (string)PlayerInfoReader[3];
                    PlayerInformation.Position = (string)PlayerInfoReader[4];
                }
            }
            catch { }
            finally
            {
                try
                {
                    PlayerInfoReader.Close();
                    PlayerInfoReader = null;
                }
                catch { }
            }
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
        */
    }
}
