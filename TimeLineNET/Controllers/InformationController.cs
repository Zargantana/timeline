using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TimeLineNET.Models;
using SharedModels;

namespace TimeLineNET.Controllers
{
    public class InformationController : ApiController
    {
        private readonly static InformationConnector _connector = new InformationConnector();

        // POST: api/Frame
        public TMInformation Post([FromBody] InfoModel value)
        {
            return readInformation(value.Username);
        }

        private TMInformation readInformation(string player)
        {
            return _connector.GetPlayerInformation(player);
        }
    }
}
