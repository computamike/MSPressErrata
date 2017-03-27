using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSPress.Startup))]
namespace MSPress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
