using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Controllers
{
    public class TestController : ApiController
    {
        
        public IHttpActionResult Get()
        {
            throw new DivideByZeroException("oops");
        }

        public IHttpActionResult GetById()
        {
            return Ok();
        }
    }
}
