using Dapper;
using StellarClothing.BuildingBlocks.Infrastructure.Dapper;
using StellarClothing.Customer.Api.Domain.CustomerAggregate;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StellarClothing.Customer.Api.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbProvider _dbProvider;

        public CustomerRepository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public async Task Add(Domain.CustomerAggregate.Customer prod)
        {
            using (IDbConnection dbConnection = _dbProvider.Connection)
            {
                string sQuery = "INSERT INTO Customers (FirstName, LastName, Address, PhoneNumber, Email, Gender, Birthday)"
                    + " VALUES(@FirstName, @LastName, @Address, @PhoneNumber, @Email, @Gender, @Birthday)";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, prod);
            }
        }

        public async Task<IEnumerable<Domain.CustomerAggregate.Customer>> GetAll()
        {
            using (IDbConnection dbConnection = _dbProvider.Connection)
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Domain.CustomerAggregate.Customer>("SELECT * FROM Customers");
            }
        }

        public async Task<Domain.CustomerAggregate.Customer> GetByID(int id)
        {
            using (IDbConnection dbConnection = _dbProvider.Connection)
            {
                string sQuery = "SELECT * FROM Customers"
                               + " WHERE CustomerId = @Id";
                dbConnection.Open();
                return (await dbConnection.QueryAsync<Domain.CustomerAggregate.Customer>(sQuery, new { Id = id })).FirstOrDefault();
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = _dbProvider.Connection)
            {
                string sQuery = "DELETE FROM Customers"
                             + " WHERE CustomerId = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, new { Id = id });
            }
        }

        public async Task Update(Domain.CustomerAggregate.Customer prod)
        {
            using (IDbConnection dbConnection = _dbProvider.Connection)
            {
                // Address, PhoneNumber, Email, Gender, Birthday
                string sQuery = "UPDATE Customers SET FirstName = @FirstName,"
                               + " LastName = @LastName"
                               + " Address = @Address"
                               + " PhoneNumber = @PhoneNumber"
                               + " Email = @Email"
                               + " Gender = @Gender"
                               + " Birthday = @Birthday"
                               + " WHERE CustomerId = @CustomerId";
                dbConnection.Open();
                await dbConnection.QueryAsync(sQuery, prod);
            }
        }
    }
}
