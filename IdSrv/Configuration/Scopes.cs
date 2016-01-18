using System;
using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace IdSrv.Configuration
{
  public class Scopes
  {
    public static IEnumerable<Scope> Get()
    {
      return new[] {

        #region identity scopes

        StandardScopes.OpenId,
        StandardScopes.Profile,
        StandardScopes.Email,
        StandardScopes.Address,
        StandardScopes.OfflineAccess,
        StandardScopes.RolesAlwaysInclude,
        StandardScopes.AllClaims,

        #endregion

        #region resource scopes

        new Scope {
          Name = "read",
          DisplayName = "Read data",
          Type = ScopeType.Resource,
          Emphasize = false,
        },
        new Scope {
          Name = "write",
          DisplayName = "Write data",
          Type = ScopeType.Resource,
          Emphasize = true,
        },
        new Scope {
          Name = "idmgr",
          DisplayName = "IdentityManager",
          Type = ScopeType.Resource,
          Emphasize = true,
          ShowInDiscoveryDocument = false,

          Claims = new List<ScopeClaim> {
            new ScopeClaim(Constants.ClaimTypes.Name),
            new ScopeClaim(Constants.ClaimTypes.Role)
          }
        }

        #endregion
      };
    }
  }
}