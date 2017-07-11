using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FloorballTrainingSessions.Startup))]
namespace FloorballTrainingSessions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
