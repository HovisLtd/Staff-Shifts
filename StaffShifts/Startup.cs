using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StaffShifts.Startup))]
namespace StaffShifts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
