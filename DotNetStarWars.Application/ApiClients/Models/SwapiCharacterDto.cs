using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

#pragma warning disable CS8618

namespace DotNetStarWars.Application.ApiClients.Models;

public class SwapiCharacterDto
{
    public string Id => Regex.Match(Url, @"/(\d+)/").Groups[1].Value;

    [JsonPropertyName("birth_year")]
    public string BirthYear { get; set; }

    [JsonPropertyName("eye_color")]
    public string EyeColor { get; set; }

    [JsonPropertyName("films")]
    public List<string> Films { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("hair_color")]
    public string HairColor { get; set; }

    [JsonPropertyName("height")]
    public string Height { get; set; }

    [JsonPropertyName("homeworld")]
    public string Homeworld { get; set; }

    [JsonPropertyName("mass")]
    public string Mass { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("skin_color")]
    public string SkinColor { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("edited")]
    public DateTime Edited { get; set; }

    [JsonPropertyName("species")]
    public List<string> Species { get; set; }

    [JsonPropertyName("starships")]
    public List<string> Starships { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("vehicles")]
    public List<string> Vehicles { get; set; }
}

