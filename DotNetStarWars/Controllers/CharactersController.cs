using DotNetStarWars.Application.ApiClients.Models;
using DotNetStarWars.Application.Commands.Characters.SyncCharacterById;
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
    public Task<SwapiGetListResponse<SwapiCharacterDto>> GetList([FromQuery] int page = 1) =>
        _mediator.Send(new GetAllCharactersRequest { Page = page });

    [HttpPut("{id}")]
    public Task<Unit> SyncCharacterById([FromRoute] int id) =>
        _mediator.Send(new SyncCharacterByIdRequest { Id = id });

    [HttpPut("sync-to-file")]
    public Task<Unit> SyncCharactersToFileRequest() =>
        _mediator.Send(new SyncCharactersToFileRequest());
}