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
                Price =300,
                IsActive = false
            };
            var domainProduct = new Product(id: product.Id,name:product.Name, price: product.Price,isActive: product.IsActive);

            return domainProduct;
        }
        public void Save(Product Product)
        {
            throw new NotImplementedException();
        }
    }
}
