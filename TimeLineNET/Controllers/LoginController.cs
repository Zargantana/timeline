using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeLineNET.Models;
using TimeLineNET.GodZillaNest;

namespace TimeLineNET.Controllers
{
    public class LoginController : ApiController
    {
        private readonly static WorldSelectConnector _connector = new WorldSelectConnector();

        // POST: api/Login
        /*
        public string Post([FromBody]LoginModel loginData)
        {
            return (loginData.PlayerName != loginData.PlayerPass) ? "" : GetPlayerToken(loginData.PlayerName);
        }*/

        private string GetPlayerToken(string playerName)
        {
            //TODO: Llamar al masterHost
            if (playerName == "Player1") return "e8b6d65a-aa79-4c7a-8c07-f8b064f60d74";
            if (playerName == "Player2") return "8b0224d8-4f1b-4742-a282-a38c50b001d9";
            return "";
        }

        /*
        public string Post(LoginModel loginData)
        {
            //Do login and get a token, and a world
            string PlayerToken = (loginData.PlayerName != loginData.PlayerPass) ? "" : GetPlayerToken(loginData.PlayerName);
            string World = "World1";
            //Select world
            if (SelectWorld(PlayerToken, World)) return PlayerToken;
            else return "";

        }*/

        public string Post(LoginModel loginData)
        {
            //Do login and get a token, and a world
            WorldModel _local = GodZilla.DoLogin(loginData);
            //Select world
            if (SelectWorld(_local.PlayerToken, _local.WorldName)) return _local.PlayerToken;
            else return "";

        }

        private bool SelectWorld(string PlayerToken, string World)
        {
            //Llamar al servicio para que cree un GameConnector para el player en ese mundo, aunque tenga que crear el mundo.
            try
            {
                _connector.SelectOrCreateWorld(PlayerToken, World);
            }
            catch (Exception e) { return false; }
            return true;
        }
    }
}
