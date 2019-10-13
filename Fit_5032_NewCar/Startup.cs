using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fit_5032_NewCar.Startup))]
namespace Fit_5032_NewCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
