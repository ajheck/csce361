using Microsoft.Owin;
using Owin;
using RoomQuery.Models;
using System;

using System.Linq;

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
