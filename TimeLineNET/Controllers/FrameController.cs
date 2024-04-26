using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeLineNET.Models;

namespace TimeLineNET.Controllers
{
    public class FrameController : ApiController
    {
        private readonly static FramesConnector _connector = new FramesConnector();

        // POST: api/Frame
        public string Post([FromBody]FrameModel value)
        {
            //return getPlayerRender(value.Username);
            return gimmyRendeer(value.Username);
        }

        private string gimmyRendeer(string player)
        {
            return _connector.GetPlayerFrame(player);
        }
    }
}
