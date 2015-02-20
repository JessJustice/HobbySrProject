using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HobbyTracker.Startup))]
namespace HobbyTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
