using System.Text.Json.Serialization;

namespace MangoTests.Models;
internal class AccessToken
{
    [JsonPropertyName("access_token")]
    public string access_token { get; set; }

    [JsonPropertyName("token_type")]
    public string token_type { get; set; }

    [JsonPropertyName("expires_in")]
    public int expires_in { get; set; }
}
