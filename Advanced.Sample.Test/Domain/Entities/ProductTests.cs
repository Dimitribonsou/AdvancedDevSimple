using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Test.Domain.Entities
{
    public class ProductTests
    {
        [Fact]
        public void ChangePrice_Should_Throw_Exception_When_Product_Is_Inactive()
        {
            var product = new Product();
            product.ChangePrice(10);

            typeof(Product).GetProperty(nameof(Product.IsActive))!.SetValue(product, false);
                
                var exception= Assert.Throws<DomainException>(()=> product.ChangePrice(20));
            Assert.Equal("Impossible de modifier un produit inactif", exception.Message);
        }
        [Fact]
        public void ApplyDiscount_Should_Decreate_Price()
        {
            var product = new Product();
            product.ChangePrice(100);

            product.ApplyDiscount(30);
            //Assert
            Assert.Equal(70,product.Price);
        }

        [Fact]
        public void ChangePrice_Should_Update_Price_When_Product_Is_Active()
        {
            // Arrange
            var product = new Product();

            // Act
            product.ChangePrice(50);

            // Assert
            Assert.Equal(50, product.Price);
        }
        [Fact]
        public void ApplyDiscount_Should_Decrease_Price()
        {
            // Arrange
            var product = new Product();
            product.ChangePrice(100);

            // Act
            product.ApplyDiscount(30);

            // Assert
            Assert.Equal(70, product.Price);
        }

        [Fact]
        public void ApplyDiscount_Should_Throw_When_Resulting_Price_Is_Invalid()
        {
            // Arrange
            var product = new Product();
            product.ChangePrice(100);

            // Act & Assert
            Assert.Throws<DomainException>(() => product.ApplyDiscount(100));
        }
    }
}
