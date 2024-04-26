using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModels;

namespace TimeFabric
{
    public class WorldEngine
    {
        private bool _stop;
        private SqlConnection connection;//To open it once
        private string connectionString;
        private Thread WorldEngineThread;

        public KeysStatesList PlayersKeysStatesList;
        private DBPlayerList PlayerList;
        private DBPlayer[] InitiativePlayerList;
        private PlayersActionsQueue PlayerActionsQueue;
        private DBObjectPartList ObjectPartList;
        private DBObjectPart[] LightObjectPartList;


        public void Start(string _connectionString)
        {
            connectionString = _connectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();

            //Open keyqueue
            PlayersKeysStatesList = new KeysStatesList();            
            PlayerList = new DBPlayerList();
            PlayerActionsQueue = new PlayersActionsQueue();
            ObjectPartList = new DBObjectPartList();

            //Start gameLoop
            WorldEngineThread = new Thread(new ThreadStart(GameLoop));
            WorldEngineThread.Start();                       
        }

        public void Stop()
        {
            _stop = true;
            WorldEngineThread.Join(500);
            WorldEngineThread.Abort();
            WorldEngineThread = null;

            connection.Close();
            connection.Dispose();
            connection = null;

            PlayerList.Clear();
            PlayerList = null;
            for (int i = 0; i < InitiativePlayerList.Length; i++) InitiativePlayerList[i] = null;
            Array.Resize<DBPlayer>(ref InitiativePlayerList, 0);

            ObjectPartList.Clear();
            ObjectPartList = null;
            for (int i = 0; i < LightObjectPartList.Length; i++) LightObjectPartList[i] = null;
            Array.Resize<DBObjectPart>(ref LightObjectPartList, 0);

            PlayerActionsQueue.Clear();
            PlayerActionsQueue = null;

            PlayersKeysStatesList.Clear();
            PlayersKeysStatesList = null;
        }

        public void SetKeyStrokes(string player, TFKeyStrokes Keys)
        {
            KeysState PlayerEnqueuedKeys;

            try
            {
                try//Por try catch porque m epueden haber cambiado la coleccion si pregunto y luego lo pillo.
                {
                    PlayerEnqueuedKeys = PlayersKeysStatesList[player];
                }
                catch
                {
                    PlayerEnqueuedKeys = new KeysState();
                    PlayersKeysStatesList[player] = PlayerEnqueuedKeys;
                }
                PlayerEnqueuedKeys.Up = Keys.Up;
                PlayerEnqueuedKeys.Down = Keys.Down;
                PlayerEnqueuedKeys.Left = Keys.Left;
                PlayerEnqueuedKeys.Right = Keys.Right;
                PlayerEnqueuedKeys.Interact = Keys.Interact;
                PlayerEnqueuedKeys.Attack = Keys.Attack;
            }
            catch { }//Si estamos apagando el motor y aun queda una connection por terminar, que no nos pete aqui dentro por null.
        }

        private void GameLoop()
        {
            _stop = false;
            while (!_stop)//Wanted: 100ms
            {
                GODmESUREITOR.StartMesure();
                GameTick(); // 4-5ms
                GC.Collect();
                System.Threading.Thread.Sleep(96); // +96ms
                GODmESUREITOR.StopMesure();
            }
        }        

        private void GameTick()
        {
            SqlTransaction Transaction = connection.BeginTransaction(IsolationLevel.Serializable);
            //SqlTransaction Transaction = null;


            //Read PlayersList
            PlayerList.Clear();
            PlayerList = new DBPlayerReader().ReadPlayerList(connection, Transaction, out InitiativePlayerList);

            //Read ObjectPartsList
            ObjectPartList.Clear();
            ObjectPartList = new DBObjectsReader().ReadObjectPartsList(connection, Transaction, out LightObjectPartList);

            try
            {
                //Process keys
                ProcessKeysQueue();

                //Process IA (Based on BD)

                //Resolve all intended actions
                ResolveIntendedActions(connection, Transaction);

                //Resolve full queue of players and mobs by initiative
                ResolveTurn(connection, Transaction);

                //Resolve players Lightning
                ResolveLightnings(connection, Transaction);

                Transaction.Commit();
            }
            catch(Exception ex1)
            {
                try
                {
                    Transaction.Rollback();
                }
                catch (Exception ex2) { }
            }            
        }

        private void ProcessKeysQueue()
        {
            KeysStatesList _lastKeysQueue = GetKeyStrokes();

            PlayerActionsQueue.Clear();
            PlayerActionsQueue = (new WEKeysProcessor()).ProcessKeysQueue(_lastKeysQueue, PlayerList);

             _lastKeysQueue.Clear();
        }

        private KeysStatesList GetKeyStrokes()
        {
            //Cambiazo
            KeysStatesList _lastQueue = PlayersKeysStatesList;
            PlayersKeysStatesList = new KeysStatesList();

            System.Threading.Thread.Sleep(0); //Let other threads do something and enqueue this to continue.

            return _lastQueue;
        }

        private void ResolveIntendedActions(SqlConnection connection, SqlTransaction Transaction)
        {
            (new WEActionsResolver()).ResolvePlayerActions(PlayerActionsQueue, PlayerList, connection, Transaction);
        }

        private void ResolveTurn(SqlConnection connection, SqlTransaction Transaction)
        {
            (new WETurnKeeper()).HacerLaRonda(InitiativePlayerList ,connection, Transaction);
        }

        private void ResolveLightnings(SqlConnection connection, SqlTransaction Transaction)
        {
            //TODO: Mob, objects and others lightnings

            //Player lightnings
            (new WELightnings()).ResetLights(connection, Transaction);
            //(new WELightnings()).PlayersLights(InitiativePlayerList, connection, Transaction);
            (new WELightnings()).PlayersLightsV2(InitiativePlayerList, connection, Transaction);            
            (new WELightnings()).ObjectPartsLights(LightObjectPartList, connection, Transaction);

        }
    }
}

