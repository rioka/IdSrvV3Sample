using System;
using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdSrvV3Sample.IdSrv.Configuration
{
  public class Clients
  {
    public static IEnumerable<Client> Get()
    {
      return new List<Client>() {
        new Client {
          ClientName = "Client Credentials Flow Client",
          Enabled = true,
          ClientId = "client",
          ClientSecrets = new List<Secret> {
            new Secret("secret".Sha256())
          },
          Flow = Flows.ClientCredentials,

          AllowedScopes = new List<string> {
            "read",
            "write"
          },

          AccessTokenType = AccessTokenType.Jwt,
          AccessTokenLifetime = 360,
        }
      };
    }
  }
}