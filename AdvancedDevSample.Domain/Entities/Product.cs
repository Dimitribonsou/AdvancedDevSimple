using AdvancedDevSample.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Domain.Entities
{
    public class Product
    {
        public Guid Id { get;   set; }
        public string Name { get; set; }
        public string Description { get; set; }= string.Empty;
        public decimal Price { get; private set; }
        public int Quantity { get;  set; }
        public bool IsActive { get;  set; }
        public Product()
        {
            IsActive = true;
        }
        //Pour l'importation depuis de la base
        public Product(string name ,decimal price, bool isActive)
        {
            this.Name = name;
            this.Id = Guid.NewGuid();
            this.Price = price;
            this.IsActive = isActive;
        }
        public Product(Guid id,string name, decimal price, bool isActive)
        {
            this.Name = name;
            this.Id = id;
            this.Price = price;
            this.IsActive = isActive;
        }
        public Product(Guid id, string name, string descritpion,decimal price, bool isActive)
        {
            this.Name = name;
            this.Id = id;
            this.Price = price;
            this.IsActive = isActive;
            this.Description= descritpion;
        }

        public void ChangePrice(decimal newprice) // Comportement
        {
             if(newprice < 0)
            {
               throw new DomainException("Le prix doit être positif");
            }
            if (!IsActive)
                throw new DomainException("Produit inactif");

             Price=newprice;
        }
        public void Update(string name, decimal price, bool isActive)
        {
            Name = name;
            ChangePrice(price);
            IsActive = isActive;
        }
        public void ApplyDiscount(decimal percentage)
        {
            var newPrice = Price - (Price * percentage / 100);

            if (newPrice <= 0)
                throw new DomainException("Le prix après réduction est invalide");

            Price = newPrice;
        }
    }
}
