using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OceanicAirlines.Startup))]
namespace OceanicAirlines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
