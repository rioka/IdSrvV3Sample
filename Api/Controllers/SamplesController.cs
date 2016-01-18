using System;
using System.Web.Http;

namespace IdSrvV3Sample.Api.Controllers
{
  public class SamplesController : ApiController
  {
    [Authorize]
    public IHttpActionResult Post()
    {
      return Ok(Guid.NewGuid());
    }

    public IHttpActionResult Get()
    {
      return Ok("Got it ("+ DateTimeOffset.UtcNow +")!");
    }
 }
}