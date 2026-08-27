using MediatR;
using CICDProject.Application.DTOs;
using CICDProject.Common;

namespace CICDProject.Application.Features.Customers.Commands;

public record CreateCustomerCommand(CreateCustomerRequestDto RequestPayload) : IRequest<ResponseModel<CustomerResponseDto>>;
