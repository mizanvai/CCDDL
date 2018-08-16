using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CASCADINGDROPDOWNLIST.Startup))]
namespace CASCADINGDROPDOWNLIST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
