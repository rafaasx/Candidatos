using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCandidatos.Startup))]
namespace WebCandidatos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
