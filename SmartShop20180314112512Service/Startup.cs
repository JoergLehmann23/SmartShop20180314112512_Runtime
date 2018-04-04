using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SmartShop20180314112512Service.Startup))]

namespace SmartShop20180314112512Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}