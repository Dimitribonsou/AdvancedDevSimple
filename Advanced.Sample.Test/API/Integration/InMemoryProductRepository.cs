using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;

namespace AdvancedDevSample.Test.API.Integration
{
    public class InMemoryProductRepository: IProductRepository
    {
        private readonly Dictionary<Guid, Product> _store = new();
        public Product GetProductById(Guid id)=> _store.TryGetValue(id, out var p) ? p: new Product();
        public void Save(Product product)
        {
            _store[product.Id] = product; 
        }

        public void Seed(Product product) => _store[product.Id] = product;
    }
}