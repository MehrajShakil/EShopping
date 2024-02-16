using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Core.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Catalog.Api.Controllers;

public class CatalogController : BaseController
{
    private readonly IMediator mediator;

    public CatalogController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    #region Products actions

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
        if(request.PageIndex == 0)
        {
            return BadRequest("Page index can not be 0.");
        }
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

    #endregion

    #region Product category actions

    [AllowAnonymous]
    [HttpGet("GetProductCategories")]
    public async Task<IActionResult> GetProductCategories()
    {
        var query = new GetAllProductCategoriesQuery();
        var categoreis = await mediator.Send(query);
        return StatusCode(200, categoreis);
    }

    // adminstrators
    [HttpPost("CreateProductCategory")]
    public async Task<IActionResult> CreateProductCategory(CreateProductCategoryCommand command)
    {
        var response = await mediator.Send(command);
        return StatusCode(200, response);
    }

    // adminstrators
    [HttpPost("UpdateProductCategory")]
    public async Task<IActionResult> UpdateProductCategory(UpdateProductCategoryCommand command)
    {
        await mediator.Send(command);
        return StatusCode(200, "Successfully Updated!");
    }

    #endregion

}
