using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/{v:apiVersion}/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
}
