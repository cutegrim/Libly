using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Libly.Startup))]
namespace Libly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
