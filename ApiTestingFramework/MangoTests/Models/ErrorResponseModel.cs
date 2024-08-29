
using Newtonsoft.Json;

namespace MangoTests.Models;

internal class ErrorResponseModel
{
    [JsonProperty("Message")]
    public string Message { get; set; }

    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("Id")]
    public string Id { get; set; }

    [JsonProperty("Date")]
    public double Date { get; set; }

    [JsonProperty("errors")]
    public Dictionary<string,string> errors { get; set; }
}
