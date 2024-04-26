using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeMachine.DB.Model;

namespace TimeMachine.DB
{
    

    public class PlayersImagesDBReader : IDisposable
    {
        public const string CONNECTING_PLAYER_ANIMATION_LEFT_IMAGE_NAME = "ConnectingLeft";
        public const string CONNECTING_PLAYER_ANIMATION_RIGHT_IMAGE_NAME = "ConnectingRight";
        public const string CONNECTING_PLAYER_ANIMATION_UP_IMAGE_NAME = "ConnectingUp";
        public const string CONNECTING_PLAYER_ANIMATION_DOWN_IMAGE_NAME = "ConnectingDown";
        public const string CONNECTING_PLAYER_STANCE_LEFT_IMAGE_NAME = "ConnectingLeft";
        public const string CONNECTING_PLAYER_STANCE_RIGHT_IMAGE_NAME = "ConnectingRight";
        public const string CONNECTING_PLAYER_STANCE_UP_IMAGE_NAME = "ConnectingUp";
        public const string CONNECTING_PLAYER_STANCE_DOWN_IMAGE_NAME = "ConnectingDown";

        private SqlConnection connection;//To open it once        
        private string connectionString;//For reconnecting
        public DBPlayersImages playersImages;


        public PlayersImagesDBReader(string _connectionstring) : base()
        {
            connectionString = _connectionstring;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void ReadWorldPlayersImages()
        {
            SqlTransaction sqlTransaction;
            
            StartReadingPlayerInfo(out sqlTransaction);
            //System.Threading.Thread.Sleep(20000);
            try
            {
                playersImages = new DBPlayersImages();
                
                List<string> players = GetPlayers(sqlTransaction);
                DBPlayerImages _local;
                foreach (string player in players)
                {
                    _local = new DBPlayerImages();
                    
                    GetPlayerLeftAnimation(sqlTransaction, player, _local);
                    GetPlayerRightAnimation(sqlTransaction, player, _local);
                    GetPlayerUpAnimation(sqlTransaction, player, _local);
                    GetPlayerDownAnimation(sqlTransaction, player, _local);
                    GetPlayerStances(sqlTransaction, player, _local);
                    
                    playersImages.Add(player, _local);
                }

                //End transaction
                sqlTransaction.Commit();

                _local = new DBPlayerImages();

                GetConnectingPlayerLeftAnimation(sqlTransaction, _local);
                GetConnectingPlayerRightAnimation(sqlTransaction, _local);
                GetConnectingPlayerUpAnimation(sqlTransaction, _local);
                GetConnectingPlayerDownAnimation(sqlTransaction, _local);
                GetConnectingPlayerStances(sqlTransaction, _local);

                playersImages.Add(Guid.Empty.ToString(), _local);                
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

        private void GetPlayerLeftAnimation(SqlTransaction transaction, string player, DBPlayerImages playerImages)
        {
            playerImages.PersonajeAnimationLeft = GetPlayerAnimation(transaction, player, "LEFT");
        }
        private void GetPlayerRightAnimation(SqlTransaction transaction, string player, DBPlayerImages playerImages)
        {
            playerImages.PersonajeAnimationRight = GetPlayerAnimation(transaction, player, "RIGHT");
        }
        private void GetPlayerUpAnimation(SqlTransaction transaction, string player, DBPlayerImages playerImages)
        {
            playerImages.PersonajeAnimationUp = GetPlayerAnimation(transaction, player, "UP");
        }
        private void GetPlayerDownAnimation(SqlTransaction transaction, string player, DBPlayerImages playerImages)
        {
            playerImages.PersonajeAnimationDown = GetPlayerAnimation(transaction, player, "DOWN");
        }

        private void GetConnectingPlayerLeftAnimation(SqlTransaction transaction, DBPlayerImages playerImages)
        {
            playerImages.PersonajeAnimationLeft = GetConnectingPlayerAnimation(transaction, CONNECTING_PLAYER_ANIMATION_LEFT_IMAGE_NAME);
        }
        private void GetConnectingPlayerRightAnimation(SqlTransaction transaction, DBPlayerImages playerImages)
        {
            playerImages.PersonajeAnimationRight = GetConnectingPlayerAnimation(transaction, CONNECTING_PLAYER_ANIMATION_RIGHT_IMAGE_NAME);
        }
        private void GetConnectingPlayerUpAnimation(SqlTransaction transaction, DBPlayerImages playerImages)
        {
            playerImages.PersonajeAnimationUp = GetConnectingPlayerAnimation(transaction, CONNECTING_PLAYER_ANIMATION_UP_IMAGE_NAME);
        }
        private void GetConnectingPlayerDownAnimation(SqlTransaction transaction, DBPlayerImages playerImages)
        {
            playerImages.PersonajeAnimationDown = GetConnectingPlayerAnimation(transaction, CONNECTING_PLAYER_ANIMATION_DOWN_IMAGE_NAME);
        }

        private const string QUERYSTRING_PLAYERS =
            "SELECT UID FROM PLAYERS";
        private List<string> GetPlayers(SqlTransaction transaction)
        {
            List<string> playerList = new List<string>();
            SqlDataReader PlayerInfoReader;
            SqlCommand command = new SqlCommand(QUERYSTRING_PLAYERS, connection, transaction);

            try
            {
                PlayerInfoReader = command.ExecuteReader();
                try
                {
                    playerList = new List<string>();
                    while (PlayerInfoReader.Read())
                    {
                        playerList.Add(((Guid)PlayerInfoReader[0]).ToString());
                    }
                }
                finally
                {
                    try
                    {
                        PlayerInfoReader.Close();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return playerList;
        }

        private const string QUERYSTRING = 
            "SELECT IMG.IMAGE " +
            "FROM " +
            "    PLAYERS PJ " +
            "    INNER JOIN PLAYER_ANIMATION_IMAGES ANI ON PJ.ANIMATION_[DIRECTION] = ANI.ANIMATION " +
            "    INNER JOIN PLAYER_IMAGES IMG ON ANI.IMAGE = IMG.UID " +
            "WHERE PJ.UID = @player " +
            "ORDER BY ANI.STEP ASC ";
        private Image[] GetPlayerAnimation(SqlTransaction transaction, string player, string animation_dir)
        {
            List<Image> animation = new List<Image>();
            SqlDataReader PlayerInfoReader;
            SqlCommand command = new SqlCommand(QUERYSTRING.Replace("[DIRECTION]",animation_dir), connection, transaction);
            command.Parameters.AddWithValue("@player", player);

            try
            {
                PlayerInfoReader = command.ExecuteReader();
                try
                {
                    while (PlayerInfoReader.Read())
                    {
                        animation.Add(Image.FromFile((string)PlayerInfoReader[0]));
                    }
                }
                finally
                {
                    try
                    {
                        PlayerInfoReader.Close();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return animation.ToArray();
        }

        private const string QUERYSTRING_CONNECTING =
            "SELECT IMG.IMAGE " +
            "FROM " +
            "    ANIMATIONS ANI " +
            "    INNER JOIN PLAYER_ANIMATION_IMAGES PANI ON PANI.ANIMATION = ANI.UID " +
            "    INNER JOIN PLAYER_IMAGES IMG ON PANI.IMAGE = IMG.UID " +
            "WHERE ANI.NAME = @animation " +
            "ORDER BY PANI.STEP ASC ";
        private Image[] GetConnectingPlayerAnimation(SqlTransaction transaction, string _animation)
        {
            List<Image> animation = new List<Image>();
            SqlDataReader PlayerInfoReader;
            SqlCommand command = new SqlCommand(QUERYSTRING_CONNECTING, connection, transaction);
            command.Parameters.AddWithValue("@animation", _animation);

            try
            {
                PlayerInfoReader = command.ExecuteReader();
                try
                {
                    while (PlayerInfoReader.Read())
                    {
                        animation.Add(Image.FromFile((string)PlayerInfoReader[0]));
                    }
                }
                finally
                {
                    try
                    {
                        PlayerInfoReader.Close();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return animation.ToArray();
        }

        private const string QUERYSTRING_PLAYERSTANCES =
            "SELECT IMGL.IMAGE, IMGR.IMAGE, IMGU.IMAGE, IMGD.IMAGE " +
            "FROM " +  
            "   PLAYERS PJ " +  
            "   INNER JOIN PLAYER_IMAGES IMGL ON PJ.IMAGE_LEFT = IMGL.UID " +  
            "   INNER JOIN PLAYER_IMAGES IMGR ON PJ.IMAGE_RIGHT = IMGR.UID " +  
            "   INNER JOIN PLAYER_IMAGES IMGU ON PJ.IMAGE_UP = IMGU.UID " +  
            "   INNER JOIN PLAYER_IMAGES IMGD ON PJ.IMAGE_DOWN = IMGD.UID " +  
            "WHERE PJ.UID = @player";
        private void GetPlayerStances(SqlTransaction transaction, string player, DBPlayerImages playerImages)
        {
            SqlDataReader PlayerInfoReader;
            SqlCommand command = new SqlCommand(QUERYSTRING_PLAYERSTANCES, connection, transaction);
            command.Parameters.AddWithValue("@player", player);

            try
            {
                PlayerInfoReader = command.ExecuteReader();
                try
                {
                    if (PlayerInfoReader.Read())
                    {
                        playerImages.PersonajeLeft = Image.FromFile((string)PlayerInfoReader[0]);
                        playerImages.PersonajeRight = Image.FromFile((string)PlayerInfoReader[1]);
                        playerImages.PersonajeUp = Image.FromFile((string)PlayerInfoReader[2]);
                        playerImages.PersonajeDown = Image.FromFile((string)PlayerInfoReader[3]);
                    }
                }
                finally
                {
                    try
                    {
                        PlayerInfoReader.Close();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private const string QUERYSTRING_CONNECTING_PLAYERSTANCES =
            "SELECT IMGL.IMAGE, IMGR.IMAGE, IMGU.IMAGE, IMGD.IMAGE " +
            "FROM " +
            "   PLAYER_IMAGES IMGL, " +
            "   PLAYER_IMAGES IMGR, " +
            "   PLAYER_IMAGES IMGU, " +
            "   PLAYER_IMAGES IMGD " +
            "WHERE IMGL.NAME = @name_left AND IMGR.NAME = @name_right AND IMGU.NAME = @name_up AND IMGD.NAME = @name_down ";
        private void GetConnectingPlayerStances(SqlTransaction transaction, DBPlayerImages playerImages)
        {
            SqlDataReader PlayerInfoReader;
            SqlCommand command = new SqlCommand(QUERYSTRING_CONNECTING_PLAYERSTANCES, connection, transaction);
            command.Parameters.AddWithValue("@name_left", CONNECTING_PLAYER_STANCE_LEFT_IMAGE_NAME);
            command.Parameters.AddWithValue("@name_right", CONNECTING_PLAYER_STANCE_RIGHT_IMAGE_NAME);
            command.Parameters.AddWithValue("@name_up", CONNECTING_PLAYER_STANCE_UP_IMAGE_NAME);
            command.Parameters.AddWithValue("@name_down", CONNECTING_PLAYER_STANCE_DOWN_IMAGE_NAME);

            try
            {
                PlayerInfoReader = command.ExecuteReader();
                try
                {
                    if (PlayerInfoReader.Read())
                    {
                        playerImages.PersonajeLeft = Image.FromFile((string)PlayerInfoReader[0]);
                        playerImages.PersonajeRight = Image.FromFile((string)PlayerInfoReader[1]);
                        playerImages.PersonajeUp = Image.FromFile((string)PlayerInfoReader[2]);
                        playerImages.PersonajeDown = Image.FromFile((string)PlayerInfoReader[3]);
                    }
                }
                finally
                {
                    try
                    {
                        PlayerInfoReader.Close();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Dispose()
        {
            foreach (System.Collections.Generic.KeyValuePair<string, DBPlayerImages> aux in playersImages)
            {
                aux.Value.PersonajeAnimationDown = null;
                aux.Value.PersonajeAnimationUp = null;
                aux.Value.PersonajeAnimationLeft = null;
                aux.Value.PersonajeAnimationRight = null;
                aux.Value.PersonajeDown = null;
                aux.Value.PersonajeUp = null;
                aux.Value.PersonajeLeft = null;
                aux.Value.PersonajeRight = null;
            }
            playersImages.Clear();

            connection.Close();
            connection.Dispose();
            connection = null;
        }
    }
}
