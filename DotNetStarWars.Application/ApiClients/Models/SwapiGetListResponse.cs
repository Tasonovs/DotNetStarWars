using System.Text.Json.Serialization;
#pragma warning disable CS8618

namespace DotNetStarWars.Application.ApiClients.Models;

public class SwapiGetListResponse<TDto>
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("previous")]
    public string Previous { get; set; }

    [JsonPropertyName("results")]
    public IEnumerable<TDto> Results { get; set; }
}