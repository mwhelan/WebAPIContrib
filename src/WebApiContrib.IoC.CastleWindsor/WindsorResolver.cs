using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel;
using IDependencyResolver = System.Web.Http.Services.IDependencyResolver;

namespace WebApiContrib.IoC.CastleWindsor
{
    public class WindsorResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public WindsorResolver(IKernel container)
        {
            this.kernel = container;
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.HasComponent(serviceType) ? this.kernel.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.ResolveAll(serviceType).Cast<object>();
        }
    }
}
