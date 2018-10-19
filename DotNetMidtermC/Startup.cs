using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetMidtermC.Startup))]
namespace DotNetMidtermC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
