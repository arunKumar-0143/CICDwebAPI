using AutoMapper;
using CICDProject.Application.DTOs;
using CICDProject.Domain.Entities;

namespace CICDProject.Application.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerResponseDto>();
        CreateMap<CreateCustomerRequestDto, Customer>();
    }
}
