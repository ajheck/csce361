using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoomQuery.Startup))]
namespace RoomQuery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
