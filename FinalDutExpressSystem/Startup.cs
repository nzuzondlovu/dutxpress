using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalDutExpressSystem.Startup))]
namespace FinalDutExpressSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
