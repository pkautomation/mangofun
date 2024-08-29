using FluentAssertions;
using Bogus;
using MangoTests.Models;
using ApiTestingFramework.Client;
using Newtonsoft.Json.Linq;

namespace MangoTests.Tests.Wallet;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class WalletTests : TestsBase
{
    public string payerId;

    [SetUp]
    public async Task SetupClass()
    {
        var newUser = new CreateNaturalUserRequestModel
        {
            FirstName = new Faker().Person.FirstName,
            LastName = new Faker().Person.LastName,
            Email = new Faker().Internet.Email(),
            Address = new Address
            {
                AddressLine1 = new Faker().Address.StreetAddress(),
                City = new Faker().Address.City(),
                Country = "FR",
                PostalCode = new Faker().Address.ZipCode()
            },
            UserCategory = "PAYER",
            TermsAndConditionsAccepted = false,
            Tag = new Faker().Random.AlphaNumeric(10)
        };

        var response = await ClientFactory.Create()
            .WithEndpoint(endpoints.NaturalUser(settings.ClientId))
            .WithAuthHeader(Token)
            .WithBody(newUser)
            .WithPost();

        dynamic responseData = JObject.Parse(response.Content!);
        payerId = Convert.ToString(responseData.Id);
    }

    [Test]
    [Description("Given Client Has Valid Credentials When The Client Requests To Create A New Wallet For An Existing User Via The API Then The API Should Return A Success Status And A Unique WalletID")]
    public async Task Given_ClientHasValidCredentials_When_TheClientRequestsToCreateANewWalletForAnExistingUserViaTheAPI_Then_TheAPIShouldReturnASuccessStatusAndAUniqueWalletID()
    {
        var newWallet = new CreateWalletRequestModel
        {
            Currency = "EUR",
            Description = new Faker().Random.AlphaNumeric(10),
            Owners = new List<string> { payerId },
        };

        var createWalletResponse = await ClientFactory.Create()
            .WithEndpoint(endpoints.Wallet(settings.ClientId))
            .WithAuthHeader(Token)
            .WithBody(newWallet)
            .WithPost();

        createWalletResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, $"Invalid response status code. Response body:{createWalletResponse.Content}");
        createWalletResponse.Content.Should().NotBeNullOrEmpty("No response body");
    }

    [Test]
    [Description("Given Client Has Valid Credentials When The Client Requests To Create A New Wallet with not existing currency For An Existing User Via The API Then The API Should Return A Bad Request response code")]
    public async Task Given_ClientHasValidCredentials_When_TheClientRequestsToCreateANewWalletWithNotExistingCurrencyForAnExistingUserViaTheAPI_Then_TheAPIShouldReturnABadRequestResponseCode()
    {
        var newWallet = new CreateWalletRequestModel
        {
            Currency = "Golden Chocolate",
            Description = new Faker().Random.AlphaNumeric(10),
            Owners = new List<string> { payerId }
        };

        var createWalletResponse = await ClientFactory.Create()
            .WithEndpoint(endpoints.Wallet(settings.ClientId))
            .WithAuthHeader(Token)
            .WithBody(newWallet)
            .WithPost<ErrorResponseModel>();

        createWalletResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest, $"Invalid response status code. Response body:{createWalletResponse.Content}");
        createWalletResponse.Content.Should().NotBeNullOrEmpty("No response body");
        createWalletResponse.Data!.errors.Keys.First().Should().Be("Currency");
    }
}
