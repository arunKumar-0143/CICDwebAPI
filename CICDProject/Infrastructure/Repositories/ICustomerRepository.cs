using CICDProject.Domain.Entities;

namespace CICDProject.Infrastructure.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    Task<Customer?> GetCustomerByCodeAsync(string customerCode, CancellationToken cancellationToken = default);
    Task<int> CreateCustomerAsync(Customer customerEntity, CancellationToken cancellationToken = default);
}
