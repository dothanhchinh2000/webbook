using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab23.Startup))]
namespace Lab23
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
