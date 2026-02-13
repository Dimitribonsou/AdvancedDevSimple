using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Infrastructure.Repositories
{
    public class EfProductRepository: IProductRepository
    {
        public Product GetProductById(Guid id)
        {
            Product product = new()
            {
                Id = id,
                Name ="Iphone 4",
                IsActive = false
            };
            
            product.ChangePrice(300);
            var domainProduct = new Product(id: product.Id,name:product.Name, price: product.Price,isActive: product.IsActive);

            return domainProduct;
        }
        public void Save(Product Product)
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id) { throw new NotImplementedException(); }
        public IEnumerable<Product> GetAll() { throw new NotImplementedException(); }
        public void Update(Product Product) { throw new NotImplementedException(); }
    }
}
