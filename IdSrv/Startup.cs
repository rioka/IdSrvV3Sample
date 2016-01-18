using IdentityServer3.Core.Configuration;
using IdSrv.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IdSrv.Startup))]

namespace IdSrv
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