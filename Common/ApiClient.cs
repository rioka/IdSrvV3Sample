using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using IdentityModel.Extensions;

namespace IdSrvV3Sample.Common
{
  public class ApiClient 
  {
    #region Public data
    
    public Uri BaseAddress { get; set; }

    #endregion
    
    #region Constructors

    public ApiClient()
      : this(ConfigurationManager.AppSettings["Api:Url"])
    {}

    public ApiClient(string baseAddress)
    {
      if (baseAddress.Last() != '/')
        baseAddress += @"/";
      BaseAddress = new Uri(baseAddress);
    }

    #endregion

    #region Apis

    public void AccessUnprotectedResource(string path)
    {
      var client = InitClient();
      Console.WriteLine("Requesting an unprotected resource...");

      try
      {
        var result = client.GetStringAsync(path).Result;
        Console.WriteLine("Result for an unprotected resource: {0}", result);
      }
      finally
      {
        client.Dispose();
      }
    }

    public void AccessProtectedResource(string path, string token = null)
    {
      var client = InitClient();
      Console.WriteLine("Requesting a protected resource...");
      if (!String.IsNullOrWhiteSpace(token))
      {
        Console.WriteLine("Setting authorization token...");
        client.SetBearerToken(token);
      }
      else
      {
        Console.WriteLine("... without an authorization token...");
      }

      var body = new Dictionary<string, string>();

      try
      {
        var result = client.PostAsync(path, new FormUrlEncodedContent(body)).Result;

        Console.WriteLine(result);

        if (result.IsSuccessStatusCode)
        {
          var content = result.Content.ReadAsStringAsync().Result;
          Console.WriteLine("Result for a protected resource: {0}", content);
        }
      }
      finally
      {
        client.Dispose();
      }
    } 

    #endregion

    #region Internals

    HttpClient InitClient()
    {
      return new HttpClient() {
        BaseAddress = BaseAddress
      };
    } 

    #endregion
  }
}
