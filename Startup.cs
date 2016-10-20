using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vendor.Startup))]
namespace Vendor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
