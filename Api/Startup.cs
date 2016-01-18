using System.Configuration;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
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
      // token validation
      app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions() {
        Authority = ConfigurationManager.AppSettings["Is:Url"],
        RequiredScopes = new[] { "write"}
      });

      var config = new HttpConfiguration();
      WebApiConfig.Register(config);

      app.UseWebApi(config);
    }
  }
}