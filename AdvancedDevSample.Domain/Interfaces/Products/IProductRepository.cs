using AdvancedDevSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Domain.Interfaces.Products
{
    public interface IProductRepository{
        Product GetProductById(Guid id);
        void Save(Product Product);
        IEnumerable<Product> GetAll();
        void Update(Product product);
        void Delete(Guid id);

    }

}
