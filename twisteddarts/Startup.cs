using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwistedDarts.Startup))]
namespace TwistedDarts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
