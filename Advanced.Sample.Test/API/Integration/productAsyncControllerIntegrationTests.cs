
using AdvancedDevSample.Domain.Entities;
using System.Net;
using System.Net.Http.Json;
using Xunit;
namespace AdvancedDevSample.Test.API.Integration
{

    public class ProductControllerIntegrationTests
        : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ProductControllerIntegrationTests(
            CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateProduct_Should_Return_Created()
        {
            var request = new
            {
                Name = "Iphone",
                Price = 1000
            };

            var response = await _client.PostAsJsonAsync(
                "/api/products", request);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_Should_Return_List()
        {
            var response = await _client.GetAsync("/api/products");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ChangePrice_Should_Return_NoContent()
        {
            var create = await _client.PostAsJsonAsync(
                "/api/products",
                new { Name = "Test", Price = 100 });

            var product = await create.Content.ReadFromJsonAsync<Product>();

            var response = await _client.PutAsJsonAsync(
                $"/api/products/{product.Id}/price",
                200);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Delete_Should_Return_NoContent()
        {
            var create = await _client.PostAsJsonAsync(
                "/api/products",
                new { Name = "ToDelete", Price = 100 });

            var product = await create.Content.ReadFromJsonAsync<Product>();

            var response = await _client.DeleteAsync(
                $"/api/products/{product.Id}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }

}
