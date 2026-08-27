using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using CICDProject.Domain.Entities;
using CICDProject.Infrastructure.Data;

namespace CICDProject.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(IDbConnectionFactory dbConnectionFactory, ILogger<CustomerRepository> logger)
    {
        _dbConnectionFactory = dbConnectionFactory;
        _logger = logger;
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        const string querySql = @"
            SELECT 
                customer_id AS CustomerId,
                customer_code AS CustomerCode,
                company_name AS CompanyName,
                contact_email AS ContactEmail,
                contact_phone AS ContactPhone,
                is_active AS IsActive,
                is_delete AS IsDelete,
                created_at_utc AS CreatedAtUtc,
                updated_at_utc AS UpdatedAtUtc
            FROM tbl_customer
            WHERE customer_id = @CustomerId
              AND is_active = true
              AND is_delete = false;";

        try
        {
            await using IDbConnection connection = await _dbConnectionFactory.CreateConnectionAsync(cancellationToken);
            
            CommandDefinition commandDefinition = new CommandDefinition(
                querySql, 
                new { CustomerId = customerId }, 
                cancellationToken: cancellationToken);

            Customer? customerEntity = await connection.QuerySingleOrDefaultAsync<Customer>(commandDefinition);
            return customerEntity;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Database error retrieving customer with ID {CustomerId}", customerId);
            throw;
        }
    }

    public async Task<Customer?> GetCustomerByCodeAsync(string customerCode, CancellationToken cancellationToken = default)
    {
        const string querySql = @"
            SELECT 
                customer_id AS CustomerId,
                customer_code AS CustomerCode,
                company_name AS CompanyName,
                contact_email AS ContactEmail,
                contact_phone AS ContactPhone,
                is_active AS IsActive,
                is_delete AS IsDelete,
                created_at_utc AS CreatedAtUtc,
                updated_at_utc AS UpdatedAtUtc
            FROM tbl_customer
            WHERE customer_code = @CustomerCode
              AND is_active = true
              AND is_delete = false;";

        try
        {
            await using IDbConnection connection = await _dbConnectionFactory.CreateConnectionAsync(cancellationToken);
            
            CommandDefinition commandDefinition = new CommandDefinition(
                querySql, 
                new { CustomerCode = customerCode }, 
                cancellationToken: cancellationToken);

            Customer? customerEntity = await connection.QuerySingleOrDefaultAsync<Customer>(commandDefinition);
            return customerEntity;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Database error retrieving customer with code {CustomerCode}", customerCode);
            throw;
        }
    }

    public async Task<int> CreateCustomerAsync(Customer customerEntity, CancellationToken cancellationToken = default)
    {
        const string insertSql = @"
            INSERT INTO tbl_customer (
                customer_id,
                customer_code,
                company_name,
                contact_email,
                contact_phone,
                is_active,
                is_delete,
                created_at_utc
            ) VALUES (
                @CustomerId,
                @CustomerCode,
                @CompanyName,
                @ContactEmail,
                @ContactPhone,
                @IsActive,
                @IsDelete,
                @CreatedAtUtc
            );";

        try
        {
            await using IDbConnection connection = await _dbConnectionFactory.CreateConnectionAsync(cancellationToken);
            
            CommandDefinition commandDefinition = new CommandDefinition(
                insertSql, 
                customerEntity, 
                cancellationToken: cancellationToken);

            int affectedRows = await connection.ExecuteAsync(commandDefinition);
            return affectedRows;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Database error creating customer with ID {CustomerId}", customerEntity.CustomerId);
            throw;
        }
    }
}
