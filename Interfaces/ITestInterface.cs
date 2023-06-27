using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace hangfireTest.Interfaces
{
    public interface ITestInterface
    {
        Task<string> MyTestFunction(string d, string a, string b);
    }
}