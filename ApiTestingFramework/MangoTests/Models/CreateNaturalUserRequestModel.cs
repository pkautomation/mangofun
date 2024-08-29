using System.Text.Json.Serialization;

namespace MangoTests.Models;
internal class CreateNaturalUserRequestModel
{
    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("LastName")]
    public string LastName { get; set; }

    [JsonPropertyName("Email")]
    public string Email { get; set; }

    [JsonPropertyName("Address")]
    public Address Address { get; set; }

    [JsonPropertyName("UserCategory")]
    public string UserCategory { get; set; }

    [JsonPropertyName("TermsAndConditionsAccepted")]
    public bool TermsAndConditionsAccepted { get; set; }

    [JsonPropertyName("Tag")]
    public string Tag { get; set; }
}
