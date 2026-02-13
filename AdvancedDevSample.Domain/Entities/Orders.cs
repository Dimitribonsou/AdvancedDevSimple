using AdvancedDevSample.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedDevSample.Domain.Exceptions;

namespace AdvancedDevSample.Domain.Entities
{
    public class Orders
    {
        public Guid Id { get; private set; }
        public string CustomerName { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsCancelled { get; private set; }

        public Orders(Guid id, string customerName, decimal totalAmount)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new DomainException("Le nom du client est obligatoire");

            if (totalAmount <= 0)
                throw new DomainException("Le montant doit être supérieur à 0");

            Id = id;
            CustomerName = customerName;
            TotalAmount = totalAmount;
            CreatedAt = DateTime.UtcNow;
            IsCancelled = false;
        }

        public void Update(string customerName, decimal totalAmount)
        {
            if (IsCancelled)
                throw new DomainException("Impossible de modifier une commande annulée");

            if (string.IsNullOrWhiteSpace(customerName))
                throw new DomainException("Le nom du client est obligatoire");

            if (totalAmount <= 0)
                throw new DomainException("Le montant doit être supérieur à 0");

            CustomerName = customerName;
            TotalAmount = totalAmount;
        }

        public void Cancel()
        {
            IsCancelled = true;
        }
    }


}
