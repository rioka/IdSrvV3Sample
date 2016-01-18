using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace IdSrvV3Sample.Api
{
  public class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // IMPORTANT: enable Route via method attributes
      config.MapHttpAttributeRoutes();

      var settings = config.Formatters.JsonFormatter.SerializerSettings;
      settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

      config.Routes.MapHttpRoute(
        "DefaultApi",
        "{controller}/{id}",
        new {
          id = RouteParameter.Optional
        }
      );
    }
  }
}