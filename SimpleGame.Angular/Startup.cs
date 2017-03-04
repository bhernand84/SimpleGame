using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleGame.Angular.Startup))]
namespace SimpleGame.Angular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
