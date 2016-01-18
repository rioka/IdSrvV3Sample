using IdentityServer3.Core.Configuration;
using IdSrvV3Sample.IdSrv;
using IdSrvV3Sample.IdSrv.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace IdSrvV3Sample.IdSrv
{
  public class Startup
  {
    public void Configuration(IAppBuilder appBuilder)
    {
      //Log.Logger = new LoggerConfiguration()
      //    .WriteTo.Trace(outputTemplate: "{Timestamp} [{Level}] ({Name}){NewLine} {Message}{NewLine}{Exception}")
      //    .CreateLogger();

      var factory = new IdentityServerServiceFactory()
                  .UseInMemoryUsers(Users.Get())
                  .UseInMemoryClients(Clients.Get())
                  .UseInMemoryScopes(Scopes.Get());

      var options = new IdentityServerOptions {
        SigningCertificate = Certificate.Load(),
        Factory = factory,
      };

      appBuilder.UseIdentityServer(options);
    }
  }
}