using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeLineNET.Models;

namespace TimeLineNET.Controllers
{
    public class ImageController : ApiController
    {
        private static int counterDebug = 0;

        // GET: api/Image
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Image/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Image
        public void Post([FromBody]ImageModel Parameter)
        {
            try
            {
                System.IO.File.WriteAllBytes("C:\\temp\\DebImg" + counterDebug.ToString().PadLeft(5, '0') + ".gif", System.Convert.FromBase64String(Parameter.Value));
            }
            catch (Exception e)
            {
                try
                {
                    System.IO.File.WriteAllText("C:\\temp\\DebImg" + counterDebug.ToString().PadLeft(5, '0') + ".txt", e.Message + "\r\n" + Parameter.Value);
                }
                catch { }
            }
            counterDebug++;
        }

        // PUT: api/Image/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Image/5
        public void Delete(int id)
        {
        }
    }
}
