using AdvancedDevSample.Application.DTO;
using AdvancedDevSample.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdvancedDevSample.Test.API.Integration
{
    public class productAsyncControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly InMemoryProductRepository _repo;
        public productAsyncControllerIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
            _repo = (InMemoryProductRepository)factory.Services.GetRequiredService<InMemoryProductRepository>();

        }
        [Fact]
        public async Task ChangePrice_Should_return_NoContent_And_Save_Product()
        {
            //Arrange
            var product = new Product();
            product.ChangePrice(10);
            _repo.Seed(product);
            var request = new ChangePriceRequest { NewPrice = 20 };
            //Act
            var response = await _client.PutAsJsonAsync($"/api/productasync/{product.Id}/price", request);
            //Assert-Http
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


    }
}
