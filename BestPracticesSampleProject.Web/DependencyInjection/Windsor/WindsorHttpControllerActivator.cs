using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BestPracticesSampleProject.Web
{
    /// <summary>
    /// Windsor activator for creating Web API controllers with dependency injection.
    /// </summary>
    public class WindsorHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainer container;

        /// <summary>
        /// Creates a new WindsorHttpControllerActivator using the specified container.
        /// </summary>
        /// <param name="container">The container which will contain the registered controllers.</param>
        public WindsorHttpControllerActivator(IWindsorContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// For the given request, creates the requested Web API controller and injects any dependencies it may have.
        /// </summary>
        /// <param name="request">The request which the controller will serve.</param>
        /// <param name="controllerDescriptor">Not used.</param>
        /// <param name="controllerType">The type of controller to create.</param>
        /// <returns>The newly created Web API controller.</returns>
        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller =
                (IHttpController)this.container.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(() => this.container.Release(controller)));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release) { this.release = release; }

            public void Dispose()
            {
                this.release();
            }
        }
    }
}