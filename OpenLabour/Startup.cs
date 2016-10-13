using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenLabour.Startup))]
namespace OpenLabour
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
