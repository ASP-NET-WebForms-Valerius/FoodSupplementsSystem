using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodSupplementsSystem.Web.Startup))]
namespace FoodSupplementsSystem.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
