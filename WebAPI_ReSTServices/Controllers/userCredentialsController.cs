using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_ReSTServices.Controllers
{
    [RoutePrefix("api/bookMe/userCredentials/v1")]
    public class userCredentialsController : ApiController
    {

        [HttpGet]
        [Route("setPassword")]
        public IHttpActionResult setPassword()
        {
            return Ok();
        }
    }
}

