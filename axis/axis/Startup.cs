using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(axis.Startup))]
namespace axis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
