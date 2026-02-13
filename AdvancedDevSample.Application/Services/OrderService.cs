using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;
using global::AdvancedDevSample.Domain.Entities;
using global::AdvancedDevSample.Domain.Interfaces.Order;
namespace AdvancedDevSample.Application.Services
{

    public class OrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public Guid Create(string customerName, decimal totalAmount)
        {
            var order = new Orders(Guid.NewGuid(), customerName, totalAmount);
            _repo.Add(order);
            return order.Id;
        }

        public Orders GetById(Guid id)
            => _repo.GetById(id) ?? throw new Exception("Commande introuvable");

        public IEnumerable<Orders> GetAll()
            => _repo.GetAll();

        public void Update(Guid id, string customerName, decimal totalAmount)
        {
            var order = GetById(id);
            order.Update(customerName, totalAmount);
            _repo.Update(order);
        }

        public void Delete(Guid id)
            => _repo.Delete(id);
    }

}
