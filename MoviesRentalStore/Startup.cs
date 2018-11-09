using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesRentalStore.Startup))]
namespace MoviesRentalStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
