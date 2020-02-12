using Simple_Dependency_Resolver.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Dependency_Resolver.Implement
{
    public class Logger : ILogger
    {
        public void LogTrace(string log)
        {
            Console.WriteLine("Write trace log: " + log);
        }
    }
}
