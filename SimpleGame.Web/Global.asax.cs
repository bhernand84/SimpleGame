using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.SignalR;
using SimpleGame.Common.Entities;
using SimpleGame.Common.Models;
using SimpleGame.Data.DataAccessLayers;
using SimpleGame.Data.Repositories;
using SimpleGame.Domain.Managers;
using SimpleGame.Web.Hubs;
using SimpleGame.Web.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleGame.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var builder = new ContainerBuilder();
            builder.RegisterHubs(Assembly.GetExecutingAssembly());

            builder.RegisterControllers(Assembly.GetExecutingAssembly()); //Register MVC Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<BasicGameRepository>().As<GameRepository>();
            builder.RegisterType<GameNotify>().SingleInstance().As<INotify>();
            builder.RegisterType<BasicGameManager>().As<GameManager>();
            builder.RegisterType<GameDAL>().As<DAL>().WithParameter(new NamedParameter("partitionKey","SimpleGame"));
//            builder.Register(typeof(GameHub), () => new GameHub(new INotify()));
            var container = builder.Build();

            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container)); //Set the MVC DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
            GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);
        }
    }
}
