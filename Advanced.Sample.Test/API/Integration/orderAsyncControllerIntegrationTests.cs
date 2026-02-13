using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Test.API.Integration
{
    public  class orderAsyncControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        public orderAsyncControllerIntegrationTests(
          CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task Create_Order_Should_Return_Created()
        {
            var response = await _client.PostAsJsonAsync("/api/orders",
                new { CustomerName = "John", TotalAmount = 200 });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

    }
}
