using DotNetStarWars.Application.ApiClients.Models;
using MediatR;

namespace DotNetStarWars.Application.Queries.Characters.GetAllCharacters;

public class GetAllCharactersRequest : IRequest<SwapiGetListResponse<SwapiCharacterDto>>
{
    public int Page { get; set; } = 1;
}