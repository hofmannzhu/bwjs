using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BWJS.WebApp.Startup))]
namespace BWJS.WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
