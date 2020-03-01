using Microsoft.Extensions.Configuration;
using StellarClothing.BuildingBlocks.Infrastructure.Dapper;
using System.Data;
using System.Data.SqlClient;

namespace StellarClothing.Customer.Api.Infrastructure
{
    public class DbProvider : IDbProvider
    {
        private readonly IConfiguration _config;

        public DbProvider(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("CustomerDb")); }
        }
    }
}
