[assembly: Microsoft.Owin.OwinStartup(typeof(cuadernito.RestAPI.Code.Startup))]

namespace cuadernito.RestAPI.Code
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            new Cqrs.WebApi.SignalR.Hubs.SignalRStartUp().Configuration(app);
        }
    }
}