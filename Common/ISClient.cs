using System;
using System.Configuration;
using System.Linq;
using IdentityModel.Client;

namespace IdSrvV3Sample.Common
{
  public class ISClient
  {
    #region Vars

    private string _baseAddress; 
    
    #endregion

    #region Public data
    
    public string BaseAddress
    {
      get { return _baseAddress; }
      set
      {
        _baseAddress = value;
        if (_baseAddress.Last() != '/')
          _baseAddress += @"/";
      }
    } 

    #endregion

    #region Constructors

    public ISClient()
      : this(ConfigurationManager.AppSettings["Is:Url"])
    {}

    public ISClient(string baseAddress)
    {
      BaseAddress = baseAddress;
    }

    #endregion

    #region Apis
    
    public TokenResponse GetClientCredentialToken()
    {
      var client = GetTokenClient();

      Console.WriteLine("Requesting a token (client credentials flow)...");
      return client.RequestClientCredentialsAsync("read write").Result;
    }

    public TokenResponse GetResourceOwnerPasswordToken(string userName, string password)
    {

      var client = GetTokenClient();

      Console.WriteLine("Requesting a token (resource owner password flow)...");
      return client.RequestResourceOwnerPasswordAsync(userName, password, "read write").Result;
    } 

    #endregion

    #region Internals

    private TokenClient GetTokenClient()
    {
      return new TokenClient(
        BaseAddress + "connect/token",
        ConfigurationManager.AppSettings["Is:Client:ClientId"],
        ConfigurationManager.AppSettings["Is:Client:Secret"]);
    } 

    #endregion
  }
}
