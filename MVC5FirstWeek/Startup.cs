using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5FirstWeek.Startup))]
namespace MVC5FirstWeek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
