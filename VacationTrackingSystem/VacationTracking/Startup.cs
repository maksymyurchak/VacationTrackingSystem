using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VacationTracking.Startup))]
namespace VacationTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
