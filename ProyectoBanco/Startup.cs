using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoBanco.Startup))]
namespace ProyectoBanco
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
