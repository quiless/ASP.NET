using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Padaria.Startup))]
namespace Padaria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
