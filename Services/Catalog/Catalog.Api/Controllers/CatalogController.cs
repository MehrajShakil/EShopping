using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Catalog.Api.Controllers;

public class CatalogController : BaseController
{
    private readonly IMediator mediator;

    public CatalogController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var query = new GetProductByIdQuery(id);
        var response = await mediator.Send(query);
        return Ok(response);
    }

}
