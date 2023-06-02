using DotNetStarWars.Application.ApiClients;
using DotNetStarWars.Application.ApiClients.Models;
using MediatR;

namespace DotNetStarWars.Application.Queries.Characters.GetAllCharacters;

public class GetAllCharactersHandler : IRequestHandler<GetAllCharactersRequest, SwapiGetListResponse<SwapiCharacterDto>>
{
    private readonly ISwapiApiClient _swapiApiClient;

    public GetAllCharactersHandler(ISwapiApiClient swapiApiClient)
    {
        _swapiApiClient = swapiApiClient;
    }

    public async Task<SwapiGetListResponse<SwapiCharacterDto>> Handle(GetAllCharactersRequest request, CancellationToken cancellationToken)
    {
        var response = await _swapiApiClient.GetAllCharacters(request.Page);

        return response;
    }
}