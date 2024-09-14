using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeMachine.DB;
using TimeMachine.DB.Model;

namespace TimeMachine
{
    public class PlayerImagesEngine
    {
        private bool _stop;

        protected static readonly Dictionary<string, DBPlayersImages> WorldsPlayersImages = new Dictionary<string, DBPlayersImages>();
        protected string PlayerUID;

        //Not in the interface, but needs to know them to properly adapt to the GameConnection
        public PlayerImagesEngine()
        {
            //TODO: Contactar con el HOST Master para pedir lista de mundos y sus conneciton strings            
        }

        public void Stop()
        {
            _stop = true;
        }

        public void Start()
        {
            //System.Threading.Thread.Sleep(20000);
            _stop = false;
            while (!_stop)
            {
                GameTick();
                System.Threading.Thread.Sleep(2000); 
            }
        }

        public void Dispose()
        {
        }

        protected void GameTick()
        {
            //TODO: Si hay cambio en PJS, cargar de nuevo una de PlayerImages y sustituir en el diccionario la instancia.
            //Todo el que vaya a usar esa instancia, solo puede trabajar en base a una copia del puntero de la instancia para evitar problemas de concurrencia.
            //FOREACH WORLD            
            if (!WorldsPlayersImages.ContainsKey("World1"))
            {
                /*(world == "World1")*/
                string ConnectionString = "data source=(local)\\SQLEXPRESS2K14;initial catalog=TimeMachine;Integrated Security=true;";
                PlayersImagesDBReader playersImagesDBReader = new PlayersImagesDBReader(ConnectionString);
                playersImagesDBReader.ReadWorldPlayersImages();
                WorldsPlayersImages.Add("World1", playersImagesDBReader.playersImages);
            } 
            else if (!WorldsPlayersImages.ContainsKey("World2"))
            {
                /*(world == "World1")*/
                string ConnectionString = "data source=(local)\\SQLEXPRESS2K14;initial catalog=TimeMachine2;Integrated Security=true;";
                PlayersImagesDBReader playersImagesDBReader = new PlayersImagesDBReader(ConnectionString);
                playersImagesDBReader.ReadWorldPlayersImages();
                WorldsPlayersImages.Add("World2", playersImagesDBReader.playersImages);
            }
            GC.Collect();
        }

        public DBPlayersImages PersonajesImages(string world)
        {
            return WorldsPlayersImages[world];
        }
    }
}
