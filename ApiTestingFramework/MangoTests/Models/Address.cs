using System.Text.Json.Serialization;

namespace MangoTests.Models;
internal class Address
{
    [JsonPropertyName("AddressLine1")]
    public string AddressLine1 { get; set; }

    [JsonPropertyName("AddressLine2")]
    public string AddressLine2 { get; set; }

    [JsonPropertyName("City")]
    public string City { get; set; }

    [JsonPropertyName("Region")]
    public string Region { get; set; }

    [JsonPropertyName("PostalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("Country")]
    public string Country { get; set; }
}
