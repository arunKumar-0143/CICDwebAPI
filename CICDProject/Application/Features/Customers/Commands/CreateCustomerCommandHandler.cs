using AutoMapper;
using MediatR;
using CICDProject.Application.DTOs;
using CICDProject.Common;
using CICDProject.Domain.Entities;
using CICDProject.Infrastructure.Repositories;

namespace CICDProject.Application.Features.Customers.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseModel<CustomerResponseDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<CustomerResponseDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        DateTime currentDateTime = DateTime.UtcNow;

        Customer? existingCustomer = await _customerRepository.GetCustomerByCodeAsync(
            request.RequestPayload.CustomerCode, 
            cancellationToken);

        if (existingCustomer != null)
        {
            return ResponseModel<CustomerResponseDto>.FailureResponse("Customer code already exists.");
        }

        Customer customerEntity = _mapper.Map<Customer>(request.RequestPayload);
        customerEntity.CustomerId = Guid.NewGuid();
        customerEntity.IsActive = true;
        customerEntity.IsDelete = false;
        customerEntity.CreatedAtUtc = currentDateTime;

        int affectedRows = await _customerRepository.CreateCustomerAsync(customerEntity, cancellationToken);
        if (affectedRows <= 0)
        {
            return ResponseModel<CustomerResponseDto>.FailureResponse("Failed to create customer record.");
        }

        CustomerResponseDto customerResponseDto = _mapper.Map<CustomerResponseDto>(customerEntity);
        return ResponseModel<CustomerResponseDto>.SuccessResponse(customerResponseDto, ResponseConstants.SUCCESS_CREATE);
    }
}
