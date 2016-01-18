using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace IdSrvV3Sample.ClientCredentialSample
{
  class Program
  {
    private static string _isBaseAddress = ConfigurationManager.AppSettings["Is:Url"];

    static void Main(string[] args)
    {
      if (_isBaseAddress.Last() != '/')
        _isBaseAddress += @"/";

      var client = new HttpClient() {
        BaseAddress = new Uri(ConfigurationManager.AppSettings["Api:Url"])
      };

      AccessUnprotectedResource(client, "samples");
      
      // unauthorized!
      AccessProtectedResource(client, "samples");
      var token = GetToken();
      // authorized
      AccessProtectedResource(client, "samples", token.AccessToken);

      client.Dispose();
    }

    private static void AccessUnprotectedResource(HttpClient client, string path)
    {
      Console.WriteLine("Requesting an unprotected resource...");
      var result = client.GetStringAsync(path).Result;

      Console.WriteLine("Result for an unprotected resource: {0}", result);
    }

    private static void AccessProtectedResource(HttpClient client, string path, string token = null)
    {
      Console.WriteLine("Requesting a protected resource...");
      if (!string.IsNullOrWhiteSpace(token))
      {
        Console.WriteLine("Setting authorization token...");
        client.SetBearerToken(token);
      }
      else
      {
        Console.WriteLine("... without an authorization token...");
      }
      
      var body = new Dictionary<string, string>();
      var result = client.PostAsync(path, new FormUrlEncodedContent(body)).Result;

      Console.WriteLine(result);

      if (result.IsSuccessStatusCode)
      {
        var content = result.Content.ReadAsStringAsync().Result;
        Console.WriteLine("Result for a protected resource: {0}", content);
      }
    }

    private static TokenResponse GetToken()
    {
      var client = new TokenClient(
        _isBaseAddress + "connect/token",
        ConfigurationManager.AppSettings["Is:Client:ClientId"],
        ConfigurationManager.AppSettings["Is:Client:Secret"]);

      Console.WriteLine("Requesting a token...");
      return client.RequestClientCredentialsAsync("read write").Result;      
    }
  }
}
