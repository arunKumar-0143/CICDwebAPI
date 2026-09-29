using AutoMapper;
using MediatR;
using CICDProject.Application.DTOs;
using CICDProject.Common;
using CICDProject.Domain.Entities;
using CICDProject.Infrastructure.Repositories;

namespace CICDProject.Application.Features.Customers.Queries;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ResponseModel<CustomerResponseDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<CustomerResponseDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Customer? customerEntity = await _customerRepository.GetCustomerByIdAsync(request.CustomerId, cancellationToken);
        if (customerEntity == null)
        {
            return ResponseModel<CustomerResponseDto>.FailureResponse(ResponseConstants.RECORD_NOT_FOUND);
        }

        CustomerResponseDto customerResponseDto = _mapper.Map<CustomerResponseDto>(customerEntity);
        return ResponseModel<CustomerResponseDto>.SuccessResponse(customerResponseDto, ResponseConstants.SUCCESS_FETCH);
    }
}
