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
        public Guid Id { get;  set; }
        public string Name { get; set; }
        public decimal Price { get;  set; }
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
        /// <summary>
        /// Modifier le prix du produit
        /// </summary>
        /// <param name="newprice">Nouveau prix du produit</param>
        /// <exception cref="DomainException">Levée si le prix est inférieur ou égal à zéro ou si le produit</exception>

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
    }
}
