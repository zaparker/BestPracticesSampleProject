using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace BestPracticesSampleProject.Web
{
    public static class ContainerConfig
    {
        private static IWindsorContainer container;

        public static IWindsorContainer Container { get { return container; } }

        public static void Config(HttpConfiguration configuration)
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            configuration.Services.Replace( typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(container));
        }
    }
}