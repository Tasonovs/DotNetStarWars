using System.Text.Json;
using DotNetStarWars.Application.ApiClients;
using DotNetStarWars.Application.ApiClients.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DotNetStarWars.Application.Commands.Characters.SyncCharactersToFile;

public class SyncCharactersToFileHandler : IRequestHandler<SyncCharactersToFileRequest, Unit>
{
    private readonly ISwapiApiClient _swapiApiClient;
    private readonly IConfiguration _configuration;

    private readonly int _maxSyncItems = 1000; // TODO Move to config
    private readonly int _apiPageSize = 10; // TODO Move to config
    private readonly JsonSerializerOptions _jsonSerializerOptions = new () { WriteIndented = true };
    
    public SyncCharactersToFileHandler(ISwapiApiClient swapiApiClient, IConfiguration configuration)
    {
        _swapiApiClient = swapiApiClient;
        _configuration = configuration;
    }
    
    public async Task<Unit> Handle(SyncCharactersToFileRequest request, CancellationToken cancellationToken)
    {
        var filePath = _configuration.GetConnectionString("CharactersFilePath")!;
        await using var streamWriter = new StreamWriter(filePath, append: false);
        
        var page = 0;
        var response = new SwapiGetListResponse<SwapiCharacterDto> { Next = "next" };
        while (!string.IsNullOrEmpty(response.Next) && page <= _maxSyncItems / _apiPageSize)
        {
            response = await _swapiApiClient.GetAllCharacters(++page);
            var jsonString = JsonSerializer.Serialize(response.Results, _jsonSerializerOptions);
            await streamWriter.WriteAsync(jsonString);
        }
        
        await streamWriter.FlushAsync();

        return Unit.Value;
    }
}