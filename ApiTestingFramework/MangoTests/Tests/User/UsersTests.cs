using FluentAssertions;
using Bogus;
using MangoTests.Models;
using ApiTestingFramework.Client;
using Newtonsoft.Json.Linq;

namespace MangoTests.Tests.User;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class UsersTests : TestsBase
{
    [Test]
    [Description("Given Client Has Valid Credentials When The Client Requests To Create A New User Via The API Then The API Should Return A Success Status And A Unique UserID")]
    public async Task Given_ClientHasValidCredentials_When_TheClientRequestsToCreateANewUserViaTheAPI_Then_TheAPIShouldReturnASuccessStatusAndAUniqueUserID()
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

        var PostTokenResponse = await ClientFactory.Create()
            .WithEndpoint(endpoints.NaturalUser(settings.ClientId))
            .WithAuthHeader(Token!)
            .WithBody(newUser)
            .WithPost();

        PostTokenResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, $"Invalid response status code. Response body:{PostTokenResponse.Content}");
        PostTokenResponse.Content.Should().NotBeNullOrEmpty("No response body");

        dynamic responseData = JObject.Parse(PostTokenResponse.Content!);
        string UserId = Convert.ToString(responseData.Id);

        UserId.Should().NotBeNullOrEmpty();
    }

    [Test]
    [Description("Given Client Has No Credentials When The Client Requests To Retrieve All Users Via The API Then The API Should Return Unauthorized Response Code")]
    public async Task Given_ClientHasValidCredentials_When_TheClientRequestsToRetrieveAllUsersViaTheAPI_Then_TheAPIShouldReturnUnauthorizedResponseCode()
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

        var PostTokenResponse = await ClientFactory.Create()
            .WithEndpoint(endpoints.NaturalUser(settings.ClientId))
            .WithBody(newUser)
            .WithPost();

        PostTokenResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized, $"Invalid response status code. Response body:{PostTokenResponse.Content}");
    }
}
