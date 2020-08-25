using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_ReSTServices.Controllers
{
    [RoutePrefix("api/testingController/v1/dev")]
    public class testingController : ApiController
    {
        [Route("ioParams/fromURIExperiment/{name}")]
        [HttpGet]
        public IHttpActionResult printValuefromURI(string name)
        {
            return Ok(name);
        }


        [Route("ioParams/fromURIExperiment")]
        [HttpGet]
        public IHttpActionResult printValuefromURI1(string name)
        {
            return Ok(name);
        }

        [Route("ioParams/fomrBodyComplexType")]
        [HttpPost]
        public IHttpActionResult printCustomer([FromBody]customer cus)
        {
            return Ok(cus);
        }


        [Route("ioParams/fromBodySimpleAndComplex")]
        public IHttpActionResult printIntandCustomer([FromUri]int passcode, [FromBody]customer c)
        {
            return Ok(passcode + "-" + c.name);
        }

        [Route("ioParams/fromURIExperiment")]
        [HttpGet]
        public IHttpActionResult printvaluefromURI([FromUri]string name)
        {

            return Ok(name);
        }


    }

    public class customer
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
