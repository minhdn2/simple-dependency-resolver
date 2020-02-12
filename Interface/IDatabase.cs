using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Dependency_Resolver.Interface
{
    public interface IDatabase
    {
        void Save(string data);
    }
}
