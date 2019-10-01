using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmissionDev.Startup))]
namespace AdmissionDev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
