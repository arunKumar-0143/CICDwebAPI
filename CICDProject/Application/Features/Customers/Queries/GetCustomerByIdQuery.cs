using MediatR;
using CICDProject.Application.DTOs;
using CICDProject.Common;

namespace CICDProject.Application.Features.Customers.Queries;

public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<ResponseModel<CustomerResponseDto>>;
