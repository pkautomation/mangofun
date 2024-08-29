using ApiTestingFramework.Client;
using FluentAssertions;
using MangoTests.Config;
using MangoTests.Constants;
using MangoTests.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text;

[SetUpFixture]
public class TestsBase
{
    internal readonly Settings settings;
    protected static string? Token;
    internal Endpoints endpoints;

    public TestsBase()
    {
        var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddUserSecrets<TestsBase>(true, true)
        .Build();

        settings = config.GetSection("Settings").Get<Settings>() ?? throw new InvalidOperationException("Settings section is missing or invalid in the configuration.");
        endpoints = new(settings.BaseUrl);
    }

    [OneTimeSetUp]
    public async Task Setup()
    {
        var bytes = Encoding.UTF8.GetBytes($"{settings!.ClientId}:{settings.ClientSecret}");

        var res = Convert.ToBase64String(bytes);

        var response = await ClientFactory.Create()
           .WithEndpoint(endpoints.Token())
           .WithHeader("Content-Type", "application/x-www-form-urlencoded")
           .WithHeader("Authorization", $"Basic {res}")
           .WithBody("grant_type=client_credentials")
           .WithPost<AccessToken>();

        response.Data.Should().NotBeNull($"Failed to retrieve access token for client {settings.ClientId}");
        response!.Data!.access_token.Should().NotBeNullOrEmpty();

        Token = response!.Data!.access_token;
    }
}