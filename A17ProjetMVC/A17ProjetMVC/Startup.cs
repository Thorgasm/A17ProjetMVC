using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A17ProjetMVC.Startup))]
namespace A17ProjetMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
