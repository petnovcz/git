using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingSessions.Startup))]
namespace TrainingSessions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
