using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
namespace PrimeWeb01.UnitTests;

public class PrimeWeb_DefaultRequestShould
{
    private readonly TestServer _server;
    private readonly HttpClient _client;
    public PrimeWeb_DefaultRequestShould()
    {
        // Arrange
        _server = new TestServer(new WebHostBuilder()
            .UseStartup<PrimeService>());
        _client = _server.CreateClient();
    }

    [Fact]
    public async Task ReturnHelloWorld()
    {
        // Act
        var response = await _client.GetAsync("/");
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Contains("Hello World!",
            responseString);
    }
}
