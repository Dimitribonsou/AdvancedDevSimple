using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Interfaces.Order;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedDevSample.Domain.Entities;


namespace AdvancedDevSample.Test.Application.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public void Create_Should_Add_Order()
        {
            var mock = new Mock<IOrderRepository>();
            var service = new OrderService(mock.Object);

            service.Create("John", 100);

            mock.Verify(r => r.Add(It.IsAny<Orders>()), Times.Once);
        }

    }
}
