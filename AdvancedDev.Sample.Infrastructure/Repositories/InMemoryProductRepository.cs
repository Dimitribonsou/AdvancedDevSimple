using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Infrastructure.Repositories
{
    public  class InMemoryProductRepository : IProductRepository
    {

        private static readonly Dictionary<Guid, Product> _products = new();

        public IEnumerable<Product> GetAll()
            => _products.Values;

        public Product? GetProductById(Guid id)
            => _products.TryGetValue(id, out var product) ? product : null;

        public void Save(Product product)
            => _products[product.Id] = product;

        public void Update(Product product)
            => _products[product.Id] = product;

        public void Delete(Guid id)
            => _products.Remove(id);
        public void Seed (Product product)
        {
            _products[product.Id]= product;
        }
    }
}
