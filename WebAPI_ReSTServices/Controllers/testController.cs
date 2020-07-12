using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_ReSTServices.Controllers
{
    [RoutePrefix("api/test/v1")]
    public class testController : ApiController
    {


        [Route("getTestMethod")]
        [HttpGet]
        public IHttpActionResult testGet(string name)
        {
            Console.WriteLine(name);
            return Ok(name);
        }


        [Route("putTestMethod")]
        [HttpPut]
        public IHttpActionResult putTest(string name)
        {
            Console.WriteLine(name);
            return Ok(name);
        }



        [Route("postTestMethod")]
        [HttpPost]
        public IHttpActionResult postTest(string name)
        {
            Console.WriteLine(name);
            return Ok(name);
        }




        [Route("deleteTestMethod")]
        [HttpDelete]
        public IHttpActionResult deleteTest(string name)
        {
            Console.WriteLine(name);
            return Ok(name);
        }


    }
}
