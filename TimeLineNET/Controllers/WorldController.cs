using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using TimeLineNET.Models;

namespace TimeLineNET.Controllers
{
    public class WorldController : ApiController
    {
        private readonly static WorldSelectConnector _connector = new WorldSelectConnector();

        // POST: api/World
        public string Post([FromBody]WorldModel worldData)
        {
            //Llamar al servicio para que cree un GameConnector para el player en ese mundo, aunque tenga que crear el mundo.

            //if (worldData.WorldName == "World1" && worldData.PlayerToken != "") return "Connected.";
            //return "";

            try
            {
                _connector.SelectOrCreateWorld(worldData.PlayerToken, worldData.WorldName);
                return "Connected! (Congrats)";
            }
            catch(Exception e)
            {
                return "Connection Error: " + e.Message;
            }

        }
    }
}
