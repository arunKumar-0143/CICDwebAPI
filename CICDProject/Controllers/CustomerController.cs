using MediatR;
using Microsoft.AspNetCore.Mvc;
using CICDProject.Application.DTOs;
using CICDProject.Application.Features.Customers.Commands;
using CICDProject.Application.Features.Customers.Queries;
using CICDProject.Common;

namespace CICDProject.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{customerId:guid}")]
    public async Task<ActionResult<ResponseModel<CustomerResponseDto>>> GetCustomerByIdAsync(
        [FromRoute] Guid customerId, 
        CancellationToken cancellationToken)
    {
        GetCustomerByIdQuery query = new GetCustomerByIdQuery(customerId);
        ResponseModel<CustomerResponseDto> response = await _mediator.Send(query, cancellationToken);

        if (!response.IsSuccess)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseModel<CustomerResponseDto>>> CreateCustomerAsync(
        [FromBody] CreateCustomerRequestDto requestPayload, 
        CancellationToken cancellationToken)
    {
        CreateCustomerCommand command = new CreateCustomerCommand(requestPayload);
        ResponseModel<CustomerResponseDto> response = await _mediator.Send(command, cancellationToken);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return CreatedAtAction(
            nameof(GetCustomerByIdAsync), 
            new { customerId = response.Data?.CustomerId }, 
            response);
    }
}
