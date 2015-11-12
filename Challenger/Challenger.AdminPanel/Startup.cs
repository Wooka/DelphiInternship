using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Challenger.AdminPanel.Startup))]
namespace Challenger.AdminPanel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
