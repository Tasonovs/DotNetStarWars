using DotNetStarWars.Application.ApiClients;
using DotNetStarWars.Application.ApiClients.Models;
using DotNetStarWars.Domain;
using DotNetStarWars.Domain.Models.Characters;
using DotNetStarWars.Domain.Models.Films;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotNetStarWars.Application.Commands.Characters.SyncCharacterById;

public class SyncCharacterByIdHandler : IRequestHandler<SyncCharacterByIdRequest, Unit>
{
    private readonly StarWarsContext _starWarsContext;
    private readonly ISwapiApiClient _swapiApiClient;
    
    public SyncCharacterByIdHandler(StarWarsContext starWarsContext, ISwapiApiClient swapiApiClient)
    {
        _starWarsContext = starWarsContext;
        _swapiApiClient = swapiApiClient;
    }
    
    public async Task<Unit> Handle(SyncCharacterByIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _swapiApiClient.GetCharacterById(request.Id);
        var existingCharacter = await _starWarsContext.Characters
            .Include(it => it.Films)
            .FirstOrDefaultAsync(it => it.OriginalId == request.Id, cancellationToken);

        if (existingCharacter != null)
        {
            _starWarsContext.Remove(existingCharacter);
            _starWarsContext.RemoveRange(existingCharacter.Films);
        }

        var character = MapToCharacter(request, response);
        
        _starWarsContext.Add(character);

        await _starWarsContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }

    private static void UpdateCharacter(Character existingCharacter, SwapiCharacterDto dto)
    {
        existingCharacter.BirthYear = dto.BirthYear;
        existingCharacter.EyeColor = dto.EyeColor;
        existingCharacter.Gender = dto.Gender;
        existingCharacter.HairColor = dto.HairColor;
        existingCharacter.Height = dto.Height;
        existingCharacter.Homeworld = dto.Homeworld;
        existingCharacter.Mass = dto.Mass;
        existingCharacter.Name = dto.Name;
        existingCharacter.SkinColor = dto.SkinColor;
        existingCharacter.Created = dto.Created;
        existingCharacter.Edited = dto.Edited;
        existingCharacter.Url = dto.Url;
        existingCharacter.Films = dto.Films
            .Select(it => new Film { Url = it })
            .ToList();
    }

    private static Character MapToCharacter(SyncCharacterByIdRequest request, SwapiCharacterDto dto)
    {
        var character = new Character
        {
            OriginalId = request.Id,
            BirthYear = dto.BirthYear,
            EyeColor = dto.EyeColor,
            Gender = dto.Gender,
            HairColor = dto.HairColor,
            Height = dto.Height,
            Homeworld = dto.Homeworld,
            Mass = dto.Mass,
            Name = dto.Name,
            SkinColor = dto.SkinColor,
            Created = dto.Created,
            Edited = dto.Edited,
            Url = dto.Url,
            Films = dto.Films
                .Select(it => new Film { Url = it })
                .ToList(),
        };
        return character;
    }
}