﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Oceanic_Airlines.DTO;

namespace Oceanic_Airlines.Api
{
    [Route("api/GetRouteDetails")]

    public class OceanicAirlinesApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        

        public IHttpActionResult Post([FromBody] string value)
        {
            return Json(new RouteDetailsDTO { price = 200, travelTime = 8 });
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}