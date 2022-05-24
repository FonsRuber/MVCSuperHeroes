using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSuperHeroes.Startup))]
namespace MVCSuperHeroes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
