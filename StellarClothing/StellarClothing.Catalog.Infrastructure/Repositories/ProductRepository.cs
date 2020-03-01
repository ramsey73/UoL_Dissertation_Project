using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using StellarClothing.Catalog.Domain;
using System;
using StellarClothing.Catalog.Domain.AggregatesModel.ProductAggregate;

namespace StellarClothing.Catalog.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionString;

        public ProductRepository()
        {
            _connectionString = "ConnectionStrings:CatalogDb";
        }

        public IDbConnection Connection;

      
        public Task Add(Product prod)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product prod)
        {
            throw new NotImplementedException();
        }
    }
}
