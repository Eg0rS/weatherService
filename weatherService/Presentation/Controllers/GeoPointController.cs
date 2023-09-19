using Common;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("user/{userId:guid}/[controller]")]
public class GeoPointController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<GeoPointController> _logger;

    public GeoPointController(IServiceManager serviceManager, ILogger<GeoPointController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet("{geoPointId:guid}")]
    public async Task<IActionResult> GetGeoPointById(Guid userId, Guid geoPointId)
    {
        var geoPointDto = await _serviceManager.GeoPointService.GetByIdAsync(userId, geoPointId);

        return Ok(geoPointDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetGeoPoints(Guid userId)
    {
        var geoPointsDto = await _serviceManager.GeoPointService.GetAllByUserIdAsync(userId);

        return Ok(geoPointsDto);
    }


    [HttpPost]
    public async Task<IActionResult> CreateGeoPoint(Guid userId, [FromBody] GeoPointForCreationDto geoPointForCreationDto)
    {
        _serviceManager.GeoPointService.Notify += (sender, e) =>
        {
            _logger.Log(LogLevel.Information, $"GeoPoint {e.ToJson()} was craeted");
            _serviceManager.GeoPointService.Notify -= (_, _) => { };
        };
        var response = await _serviceManager.GeoPointService.CreateAsync(userId, geoPointForCreationDto);

        return CreatedAtAction(nameof(GetGeoPointById), new { userId = response.UserId, geoPointId = response.Id }, response);
    }

    [HttpDelete("{geoPointId:guid}")]
    public async Task<IActionResult> DeleteGeoPoint(Guid userId, Guid geoPointId)
    {
        _serviceManager.GeoPointService.Notify += (sender, e) =>
        {
            _logger.Log(LogLevel.Information, $"GeoPoint {e.ToJson()} was deleted");
            _serviceManager.GeoPointService.Notify -= (_, _) => { };
        };
        await _serviceManager.GeoPointService.DeleteAsync(userId, geoPointId);

        return NoContent();
    }

    [HttpPut("{geoPointId:guid}")]
    public async Task<IActionResult> UpdateGeoPoint(Guid userId, Guid geoPointId, [FromBody] GeoPointForUpdateDto geoPointForUpdateDto)
    {
        _serviceManager.GeoPointService.Notify += (sender, e) =>
        {
            _logger.Log(LogLevel.Information, $"GeoPoint {e.ToJson()} was updated");
            _serviceManager.GeoPointService.Notify -= (_, _) => { };
        };
        await _serviceManager.GeoPointService.UpdateAsync(userId, geoPointId, geoPointForUpdateDto);

        return NoContent();
    }
}