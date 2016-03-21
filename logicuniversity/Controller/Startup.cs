using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(logicuniversity.Startup))]
namespace logicuniversity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);
        }
    }
}
