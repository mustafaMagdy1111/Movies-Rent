using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movies_Rent.Startup))]
namespace Movies_Rent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
