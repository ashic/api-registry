using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApiRegistry.Startup))]
namespace ApiRegistry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
