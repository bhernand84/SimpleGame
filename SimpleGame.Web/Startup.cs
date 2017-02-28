using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;
using SimpleGame.Web.ServiceBus;
using SimpleGame.Web.Hubs;

[assembly: OwinStartup(typeof(SimpleGame.Web.Startup))]

namespace SimpleGame.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(typeof(GameHub), () => new GameHub(new GameNotify()));
            //app.UseCors(CorsOptions.AllowAll);
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);

                var hubConfig = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    EnableJSONP = true
                };
                map.RunSignalR(hubConfig);
            });

        }

    }
}
