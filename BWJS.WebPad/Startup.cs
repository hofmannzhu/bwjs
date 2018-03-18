using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BWJS.WebPad.Startup))]
namespace BWJS.WebPad
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
