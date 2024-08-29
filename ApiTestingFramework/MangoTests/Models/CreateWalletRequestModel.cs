using Newtonsoft.Json;

namespace MangoTests.Models;

internal class CreateWalletRequestModel
{
    [JsonProperty("Owners")]
    public List<string> Owners { get; set; }

    [JsonProperty("Description")]
    public string Description { get; set; }

    [JsonProperty("Currency")]
    public string Currency { get; set; }

    [JsonProperty("Tag")]
    public string Tag { get; set; }
}
