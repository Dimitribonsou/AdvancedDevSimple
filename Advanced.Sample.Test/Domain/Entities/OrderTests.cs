using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Test.Domain.Entities
{
    public class OrderTests
    {

        [Fact]
        public void Should_Create_Order()
        {
            var order = new Orders(Guid.NewGuid(), "John", 100);

            Assert.Equal("John", order.CustomerName);
            Assert.Equal(100, order.TotalAmount);
        }

        [Fact]
        public void Should_Throw_When_Total_Is_Invalid()
        {
            Assert.Throws<DomainException>(() =>
                new Orders(Guid.NewGuid(), "John", 0));
        }
    }

}
