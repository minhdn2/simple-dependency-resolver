using Simple_Dependency_Resolver.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Dependency_Resolver.Implement
{
    public class Database : IDatabase
    {
        private readonly ILogger _log;

        public Database(ILogger log)
        {
            _log = log;
        }
        public void Save(string data)
        {
            _log.LogTrace("Write to database: " + data);
        }
    }
}
