using System.ComponentModel.DataAnnotations;
using DotNetStarWars.Domain.Models.Characters;

namespace DotNetStarWars.Domain.Models.Films;
#pragma warning disable CS8618

public class Film
{
    public long Id { get; set; }

    [MaxLength(255)]
    public string Url { get; set; }
    
    public List<Character> Characters { get; set; } = new();
}