using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatingSida.Startup))]
namespace DatingSida
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
