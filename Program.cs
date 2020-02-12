using Simple_Dependency_Resolver.Implement;
using Simple_Dependency_Resolver.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Dependency_Resolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Container.Register<ILogger, Logger>();
            Container.Register<IDatabase, Database>();

            Container.Register<Cart, Cart>();

            var myCart = Container.ResolveType<Cart>();
            myCart.Checkout();
        }
    }
}
