using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace ProblemTest
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container)
        {
            _container = container;
        }

        private readonly IContainer _container;        

        public object GetService(Type serviceType)
        {

            if (serviceType == null)
                return null;

            return serviceType.IsAbstract || serviceType.IsInterface
                     ? _container.TryGetInstance(serviceType)
                     : _container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}