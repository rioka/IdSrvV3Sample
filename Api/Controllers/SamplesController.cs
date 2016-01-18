using System;
using System.Web.Http;

namespace IdSrvV3Sample.Api.Controllers
{
  public class SamplesController : ApiController
  {
    public IHttpActionResult Post()
    {
      return Ok(Guid.NewGuid());
    }
  }
}