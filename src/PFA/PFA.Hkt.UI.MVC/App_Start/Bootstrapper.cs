using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Resolver;
using Unity.Mvc3;

namespace PFA.Hkt.UI.MVC
{
    public class Bootstrapper
    {

        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
 
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();       
            // container.RegisterType<IProductServices, ProductServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "PFA.Hkt.UI.MVC.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "BusinessModel.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "DataModel.dll");

        }

    }
}