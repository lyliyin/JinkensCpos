using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CPOS.Startup))]
namespace CPOS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
