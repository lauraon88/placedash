using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlacementDashboard.Startup))]
namespace PlacementDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
