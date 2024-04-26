using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineNET.Models;

namespace TimeLineNET.GodZillaNest
{
    public class WorldModelEx: WorldModel
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class GodZilla
    {
        

        public static WorldModel DoLogin(LoginModel credentials)
        {
            return (new GodZilla()).Login(credentials);
        }

        public WorldModel Login(LoginModel credentials)
        {
            WorldModelEx Destination;
            //Do DB validation of credentials.
            //Generate a GUID.
            //Delete current user from loguedinusers .
            //Delete instances of the user GUID from worlds.
            //Save GUID in loguedinUsers with current world and startup position.
            Egg Thrall = new Egg();
            Destination = Thrall.PutIt(credentials);
            //Insert player to its first world in the given position

            //Return the WorldModel.
            return (WorldModel)Destination;
        }

        public bool WorldTransfer(WorldModel From, WorldModelEx To)
        {
            //El server habrá puesto una animaciónm de transferring si le piden frames. 
            //Keys a null e info engine a nothings y 0s.
            //La gameconnection habrá parado el generador de frames, info engine, keys engine... 
            //Se hace la copia del PJ (MOVE)
            //Se devuelve la nueva connection string
            //La gameconnection  reactiva engines con la nueva connectionstring
            //Se reconecta el frames al nuevo mundo, así como el keys, info,...
            return true;
        }
    }
}
