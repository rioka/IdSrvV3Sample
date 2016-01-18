using System;
using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdSrvV3Sample.IdSrv.Configuration
{
  public class Clients
  {
    static readonly int TenMinutes = 360;
    
    public static IEnumerable<Client> Get()
    {
      return new List<Client>() {
        GetAClientCredentialFlowClient(),
        GetAResourceOwnerFlowClient()
      };
    }

    #region Internals

    private static Client GetAResourceOwnerFlowClient()
    {
      return new Client {
        ClientName = "Resource Owner Flow Client",
        Enabled = true,
        ClientId = "roclient",
        ClientSecrets = new List<Secret> {
          new Secret("secret".Sha256())
        },
        Flow = Flows.ResourceOwner,

        AllowedScopes = new List<string> {
          "read",
          "write"
        },

        AccessTokenType = AccessTokenType.Jwt,
        AccessTokenLifetime = TenMinutes,
      };

    }

    static Client GetAClientCredentialFlowClient()
    {
      return new Client {
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
        AccessTokenLifetime = TenMinutes,
      };
    } 

    #endregion      
  }
}