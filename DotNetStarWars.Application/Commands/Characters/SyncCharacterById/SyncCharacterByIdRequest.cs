using MediatR;

namespace DotNetStarWars.Application.Commands.Characters.SyncCharacterById;

public class SyncCharacterByIdRequest : IRequest<Unit>
{
    public long Id { get; set; }
}