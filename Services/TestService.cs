using hangfireTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace hangfireTest.Services
{
    public class TestService : ITestInterface
    {
        public Task<string> MyTestFunction(string d, string a, string b)
        {
            string aaa = a + " is a " + b + " and " + d;
            return Task.FromResult(aaa);
        }
    }
}