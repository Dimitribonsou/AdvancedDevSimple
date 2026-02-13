using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;
        public ProductService( IProductRepository repo) {
            _repo = repo;
        }
        private Product GetProduct(Guid productId)
        {
            return _repo.GetProductById(productId) ?? throw new Exception("Produit introuvable");
        }
        public IEnumerable<Product> GetAll()
    => _repo.GetAll();

        public Product GetById(Guid id)
            => _repo.GetProductById(id)
               ?? throw new Exception("Produit introuvable");

        public Guid Create(string name, decimal price, bool isActive)
        {
            var product = new Product(Guid.NewGuid(), name, price, isActive);
            _repo.Save(product);
            return product.Id;
        }

        public void Update(Guid id, string name, decimal price, bool isActive)
        {
            var product = GetById(id);
            product.Update(name, price, isActive);
            _repo.Update(product);
        }

        public void ChangeProductPrice(Guid id, decimal price)
        {
            var product = GetById(id);
            product.ChangePrice(price);
            _repo.Update(product);
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }
    }
}
