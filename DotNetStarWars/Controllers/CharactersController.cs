using DotNetStarWars.Application.ApiClients.Models;
using DotNetStarWars.Application.Commands.Characters.SyncCharactersToFile;
using DotNetStarWars.Application.Queries.Characters.GetAllCharacters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetStarWars.Controllers;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CharactersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<SwapiGetListResponse<SwapiCharacterDto>> GetList([FromQuery] int page) =>
        _mediator.Send(new GetAllCharactersRequest { Page = page });

    [HttpPut("sync-to-file")]
    public Task<Unit> SyncCharactersToFileRequest() =>
        _mediator.Send(new SyncCharactersToFileRequest());
}