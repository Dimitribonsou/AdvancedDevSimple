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
        public InMemoryOrderRepository()
        {
            Seed();
        }
        private void Seed()
        {
            var order1 = new Orders(
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                "Alice",
                250
            );

            var order2 = new Orders(
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                "Bob",
                450
            );

            var order3 = new Orders(
                Guid.Parse("33333333-3333-3333-3333-333333333333"),
                "Charlie",
                120
            );

            _orders[order1.Id] = order1;
            _orders[order2.Id] = order2;
            _orders[order3.Id] = order3;
        }

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
