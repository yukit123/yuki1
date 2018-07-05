using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestApplication2.Startup))]
namespace TestApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
