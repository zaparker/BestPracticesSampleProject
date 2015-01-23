using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace BestPracticesSampleProject.Web
{
    /// <summary>
    /// Windsor controller factory for creating MVC controllers with dependency injection.
    /// </summary>
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;
        
        /// <summary>
        /// Creates a new WindsorControllerFactory using the specified Windsor kernel.
        /// </summary>
        /// <param name="kernel">The kernel which will be used to resolve the controllers.</param>
        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Releases the specified controller.
        /// </summary>
        /// <param name="controller">The controller to release.</param>
        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        /// <summary>
        /// Resolves a controller instance and resolves any dependencies it may have.
        /// </summary>
        /// <param name="requestContext">The RequestContext. Not used.</param>
        /// <param name="controllerType">The type of MVC controller to create.</param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)kernel.Resolve(controllerType);
        }
    }
}