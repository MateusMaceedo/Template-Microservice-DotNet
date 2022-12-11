using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.API.Controllers.Base
{
    [ApiController]
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {

    }
}
