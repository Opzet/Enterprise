using Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{
    public class MessageController : ApiController
    {
        // Static storage to simulate database
        private static string _storedMessage = "Initial Message";

        // GET api/data
        public IHttpActionResult Get()
        {
            return Ok(_storedMessage);
        }

        // POST api/data
        public IHttpActionResult Post([FromBody] string value)
        {
            // Store the received message
            _storedMessage = value;

            // Process the received data and store it in a database
            CRUDWebApiDb.Create(value);

            // Return a success code with a message
            return Ok("Message stored successfully");
        }
    }
}
