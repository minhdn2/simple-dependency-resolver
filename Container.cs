using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Dependency_Resolver
{
    public class Container
    {
        private static readonly Dictionary<Type, object> ResgisteredModules = new Dictionary<Type, object>();

        public static void Register<TInterface, TModule>()
        {
            SetModule(typeof(TInterface), typeof(TModule));
        }

        private static void SetModule(Type interfaceType, Type moduleType)
        {
            if (!interfaceType.IsAssignableFrom(moduleType))
            {
                throw new Exception("Wrong Module type");
            }

            //Find constructor
            var firstConstructor = moduleType.GetConstructors()[0];
            object module;
            //For parameterless constructor
            if (!firstConstructor.GetParameters().Any())
            {
                //Initialize the object
                module = firstConstructor.Invoke(null);
            }
            else
            {
                var constructorParameters = firstConstructor.GetParameters();
                var moduleDependecies = new List<object>();
                foreach (var parameter in constructorParameters)
                {
                    var dependency = GetModule(parameter.ParameterType);
                    moduleDependecies.Add(dependency);
                }
                module = firstConstructor.Invoke(moduleDependecies.ToArray());
            }
            ResgisteredModules.Add(interfaceType, module);
        }

        public static T ResolveType<T>()
        {
            return (T)GetModule(typeof(T));
        }

        private static object GetModule(Type interfaceType)
        {
            if (ResgisteredModules.ContainsKey(interfaceType))
            {
                return ResgisteredModules[interfaceType];
            }
            throw new Exception("Module not register");
        }
    }
}
