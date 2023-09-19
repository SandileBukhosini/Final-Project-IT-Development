using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BriteHouse.Startup))]
namespace BriteHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
