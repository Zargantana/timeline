using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeLineNET.Models;
using SharedModels;

namespace TimeLineNET.Controllers
{
    public class KeysController : ApiController
    {
        private readonly static KeysConnector _connector = new KeysConnector();

        // POST: api/Keys
        public void Post([FromBody]KeysModel value)
        {
            enqueueKeys(value.Username, value.Keys);
        }

        private void enqueueKeys(string player, KeyState Keys)
        {
             _connector.SetKeystrokes(player, ChangeStructures(Keys)); //TODO: Serialize keys
        }

        private TMKeyStrokes ChangeStructures(KeyState Keys)
        {
            TMKeyStrokes _result = new TMKeyStrokes();
            
            _result.Key_P = Keys.Key_P;
            _result.Key_O = Keys.Key_O;
            _result.Key_Q = Keys.Key_Q;
            _result.Key_A = Keys.Key_A;
            _result.Key_W = Keys.Key_W;
            _result.Key_D = Keys.Key_D;
            _result.Key_S = Keys.Key_S;
            _result.Key_E = Keys.Key_E;
            _result.Key_SP = Keys.Key_SP;

            return _result;

        }
    }
}
