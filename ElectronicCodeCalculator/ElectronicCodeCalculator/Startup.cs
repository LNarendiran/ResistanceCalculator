using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectronicCodeCalculator.Startup))]
namespace ElectronicCodeCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
