using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApi;
using Xunit;

namespace IntegrationTests
{
    public class EmployeeTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient _client;

        public EmployeeTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }
        
        [Fact]
        public async Task TestGetEmployeesAsync()
        {
            // Arrange
            var request = "/Employee";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}