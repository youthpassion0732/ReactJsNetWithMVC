using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReactJs.NetWithMVC.Startup))]
namespace ReactJs.NetWithMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
