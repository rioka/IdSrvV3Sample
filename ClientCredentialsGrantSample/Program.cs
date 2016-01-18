using System;
using IdSrvV3Sample.Common;

namespace IdSrvV3Sample.ClientCredentialsGrantSample
{
  class Program
  {
    static void Main(string[] args)
    {
      var client = new ApiClient();

      client.AccessUnprotectedResource("samples");
      
      // unauthorized!
      client.AccessProtectedResource("samples");

      // authorized
      var token = new ISClient().GetClientCredentialToken();
      client.AccessProtectedResource("samples", token.AccessToken);

      Console.ReadLine();
    }
  }
}
