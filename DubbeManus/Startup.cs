using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DubbeManus.Startup))]
namespace DubbeManus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
