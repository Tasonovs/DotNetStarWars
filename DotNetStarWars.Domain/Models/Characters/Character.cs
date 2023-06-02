using System.ComponentModel.DataAnnotations;
using DotNetStarWars.Domain.Models.Films;

#pragma warning disable CS8618

namespace DotNetStarWars.Domain.Models.Characters;

public class Character
{
    public long Id { get; set; }
    
    public long OriginalId { get; set; }
    
    [MaxLength(50)]
    public string BirthYear { get; set; }

    [MaxLength(50)]
    public string EyeColor { get; set; }

    [MaxLength(50)]
    public string Gender { get; set; }

    [MaxLength(50)]
    public string HairColor { get; set; }

    [MaxLength(50)]
    public string Height { get; set; }

    [MaxLength(50)]
    public string Homeworld { get; set; }

    [MaxLength(50)]
    public string Mass { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string SkinColor { get; set; }

    public DateTime Created { get; set; }

    public DateTime Edited { get; set; }

    [MaxLength(255)]
    public string Url { get; set; }

    public List<Film> Films { get; set; } = new();
}