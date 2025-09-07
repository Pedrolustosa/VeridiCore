using MediatR;
using Microsoft.AspNetCore.Mvc;
using VeridiCore.API.Contracts.Transactions;
using VeridiCore.Application.UseCases.Transactions.Commands;
using VeridiCore.Application.UseCases.Transactions.Queries;

namespace VeridiCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    private Guid GetCurrentUserId() => Guid.Parse("F4D2F8C8-8F8E-4B2A-8F8E-4B2A8F8E4B2A");

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransactionRequest request)
    {
        var command = new CreateTransactionCommand(
            request.Title,
            request.Amount,
            request.Type,
            request.PaidOrReceivedAt,
            request.CategoryId,
            GetCurrentUserId());

        var transactionId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = transactionId }, new { id = transactionId });
    }

    [HttpGet]
    public async Task<IActionResult> GetByPeriod([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var query = new GetTransactionsByPeriodQuery(GetCurrentUserId(), startDate, endDate);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:guid}", Name = "GetTransactionById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTransactionByIdQuery(id, GetCurrentUserId());
        var result = await _mediator.Send(query);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTransactionRequest request)
    {
        var command = new UpdateTransactionCommand(
            id,
            request.Title,
            request.Amount,
            request.PaidOrReceivedAt,
            request.CategoryId,
            GetCurrentUserId());

        var success = await _mediator.Send(command);

        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteTransactionCommand(id, GetCurrentUserId());
        var success = await _mediator.Send(command);

        return success ? NoContent() : NotFound();
    }
}