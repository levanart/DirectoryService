using DirectoryService.Application.Locations;
using DirectoryService.Contracts.Locations;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[Route("/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly ILocationsService _service;

    public LocationsController(ILocationsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationDto request,
        CancellationToken cancellationToken)
    {
        var createdLocationId = await _service.CreateLocationAsync(request, cancellationToken);
        return Ok(createdLocationId);
    }
}