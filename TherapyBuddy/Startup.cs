using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TherapyBuddy.Startup))]
namespace TherapyBuddy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
