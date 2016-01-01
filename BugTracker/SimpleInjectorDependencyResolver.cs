using System;
using NRules;
using SimpleInjector;

namespace BugTracker
{
    public class SimpleInjectorDependencyResolver : IDependencyResolver
    {
        private readonly Container container;

        public SimpleInjectorDependencyResolver(Container container)
        {
            this.container = container;
        }

        public object Resolve(IResolutionContext context, Type serviceType)
        {
            return container.GetInstance(serviceType);
        }
    }
}