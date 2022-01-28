using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FireLocator.Startup))]
namespace FireLocator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
