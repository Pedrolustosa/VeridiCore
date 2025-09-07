using MediatR;
using Microsoft.AspNetCore.Mvc;
using VeridiCore.API.Contracts.Categories;
using VeridiCore.Application.UseCases.Categories.Queries;
using VeridiCore.Application.UseCases.Categories.Commands;

namespace VeridiCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    private static Guid GetCurrentUserId()
    {
        return Guid.Parse("f4d2f8c8-8f8e-4b2a-8f8e-4b2a8f8e4b2a");
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetCurrentUserId();
        var query = new GetAllCategoriesByUserQuery(userId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetCategoryById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCategoryByIdQuery(id);
        var result = await _mediator.Send(query);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        var userId = GetCurrentUserId();
        var command = new CreateCategoryCommand(request.Name, request.Description, request.Type, userId);
        var categoryId = await _mediator.Send(command);
        return CreatedAtRoute("GetCategoryById", new { id = categoryId }, new { id = categoryId });
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryRequest request)
    {
        var command = new UpdateCategoryCommand(id, request.Name, request.Description);
        var success = await _mediator.Send(command);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCategoryCommand(id);
        var success = await _mediator.Send(command);
        return success ? NoContent() : NotFound();
    }
}