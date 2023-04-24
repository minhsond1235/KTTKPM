using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviePenguin.Startup))]
namespace MoviePenguin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
