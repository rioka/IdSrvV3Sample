﻿using System;
using System.Configuration;
using IdSrvV3Sample.Common;

namespace IdSrvV3Sample.ResourceOwnerSample
{
  class Program
  {
    private static string _isBaseAddress = ConfigurationManager.AppSettings["Is:Url"];
    
    static void Main(string[] args)
    {
      var client = new ApiClient();

      client.AccessUnprotectedResource("samples");

      var token = new ISClient().GetResourceOwnerPasswordToken(ConfigurationManager.AppSettings["Is:UserName"],
                                                               ConfigurationManager.AppSettings["Is:Password"]);
      // authorized
      client.AccessProtectedResource("samples", token.AccessToken);

      Console.ReadLine();
    }
  }
}
