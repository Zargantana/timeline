using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeMachine.DB;

namespace TimeMachine
{
    public class PlayerInfoEngine
    {
        private bool _stop;

        protected TMInformationMultiBuffer PlayerInfoBuffer;
        protected PlayerInfoDBReader playerInfoDBReader;
        protected string PlayerUID;

        //Not in the interface, but needs to know them to properly adapt to the GameConnection
        public PlayerInfoEngine(string player, string world, TMInformationMultiBuffer InformationBuffer)
        {
            string ConnectionString = "";

            PlayerInfoBuffer = InformationBuffer;
            //TODO: Contactar con el HOST Master para pedir la connectionString a BD de WorldInstance a cambio de asignar el PJ a ese WorldInstance y escribir su template
            //TODO: También nos tiene que dar la info para pintar al PJ: Animation sprites, ...
            //El player UID que se usará a partir de ahora   
            PlayerUID = player;
            if (world == "World1") ConnectionString = "data source=(local)\\SQLEXPRESS2K14;initial catalog=TimeMachine;Integrated Security=true;";

            playerInfoDBReader = new PlayerInfoDBReader(PlayerUID, ConnectionString);
        }

        public void Stop()
        {
            _stop = true;
        }

        public void Start()
        {
            _stop = false;
            while (!_stop)//Wanted: 40ms
            {
                GameTick(); // +x ms
                System.Threading.Thread.Sleep(480); // +900ms
            }
        }

        public void Dispose()
        {
            playerInfoDBReader.Dispose();
            PlayerInfoBuffer = null;
        }

        protected void GameTick()
        {
            playerInfoDBReader.ReadPlayerInfoData();
            PlayerInfoBuffer.writeNew(playerInfoDBReader.PlayerInformation);
            GC.Collect();
        }
    }
}
