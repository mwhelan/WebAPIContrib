using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel;

namespace WebApiContrib.IoC.CastleWindsor
{
    public class WindsorHttpControllerFactory : DefaultHttpControllerFactory
    {
        private readonly IKernel kernel;

        public WindsorHttpControllerFactory(HttpConfiguration configuration, IKernel kernel)
            : base(configuration)
        {
            this.kernel = kernel;
        }

        public override void ReleaseController(IHttpController controller)
        {
            this.kernel.ReleaseComponent(controller);
            base.ReleaseController(controller);
        }
    }
}