using hangfireTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace hangfireTest.Controllers
{
    public class MyTestController : ApiController
    {
        public readonly TestService testService;
        public MyTestController(TestService test) {
            testService = test;
        }

        [HttpGet]
        public Task<string> test1()
        {
            return testService.MyTestFunction("brave", "Mushhood", "alpha");
        }
    }
}
