using AdvancedDevSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdvancedDevSample.Domain.Interfaces.Order
{

    public interface IOrderRepository
    {
        Orders? GetById(Guid id);
        IEnumerable<Orders> GetAll();
        void Add(Orders order);
        void Update(Orders order);
        void Delete(Guid id);
    }

}
