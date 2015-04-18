using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMenu.Website.Startup))]
namespace EMenu.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
