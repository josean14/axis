using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AXIS.Startup))]
namespace AXIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
