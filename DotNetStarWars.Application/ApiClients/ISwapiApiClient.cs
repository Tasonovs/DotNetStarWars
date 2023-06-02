using DotNetStarWars.Application.ApiClients.Models;
using Refit;

namespace DotNetStarWars.Application.ApiClients;

public interface ISwapiApiClient
{
    [Get("/api/people?page={page}")]
    Task<SwapiGetListResponse<SwapiCharacterDto>> GetAllCharacters(int page);

    [Get("/api/people/{id}")]
    Task<SwapiCharacterDto> GetCharacterById(long id);

}