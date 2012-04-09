using System.Reflection;
using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace WebApiContrib.IoC.CastleWindsor
{
    public static class RegistrationExtensions
    {
        public static void RegisterApiControllers(this IWindsorContainer container, params Assembly[] controllerAssemblies)
        {
            foreach (var assembly in controllerAssemblies)
            {
                container.Register(
                    AllTypes
                        .FromAssembly(assembly)
                        .BasedOn<IHttpController>()
                        .LifestyleTransient());
            }
        }
    }
}