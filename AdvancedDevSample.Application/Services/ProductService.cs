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
        public void ChangeProductPrice(Guid productId,decimal newPrice) { 

            var product= GetProduct(productId);
            product.ChangePrice(newPrice);
            _repo.Save(product);
        }
        private Product GetProduct(Guid productId)
        {
            return _repo.GetProductById(productId) ?? throw new Exception("Produit introuvable");
        }
    }
}
