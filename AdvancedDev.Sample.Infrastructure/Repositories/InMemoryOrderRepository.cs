using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;
using global::AdvancedDevSample.Domain.Entities;
using global::AdvancedDevSample.Domain.Interfaces.Order;



namespace AdvancedDevSample.Infrastructure.Repositories
{

    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, Orders> _orders = new();

        public void Add(Orders order)
            => _orders[order.Id] = order;

        public void Delete(Guid id)
            => _orders.Remove(id);

        public IEnumerable<Orders> GetAll()
            => _orders.Values;

        public Orders? GetById(Guid id)
            => _orders.TryGetValue(id, out var order) ? order : null;

        public void Update(Orders order)
            => _orders[order.Id] = order;
    }

}
