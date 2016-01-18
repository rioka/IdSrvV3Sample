using System.Web.Http;
using IdSrvV3Sample.Api;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace IdSrvV3Sample.Api
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();
      WebApiConfig.Register(config);

      app.UseWebApi(config);
    }
  }
}