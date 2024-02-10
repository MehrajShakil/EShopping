using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Core.Pagination;
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
    [Route("GetProductById")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var query = new GetProductByIdQuery(id);
        var response = await mediator.Send(query);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    [Route("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts(PageItemRequest request)
    {
        var query = new GetAllProductsQuery(request);
        var response = await mediator.Send(query);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        var response = await mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    [Route("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
    {
        var response = await mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    [Route("DeleteProduct")]  
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var command = new DeleteProductByIdCommand(id);
        var response = await mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

}
