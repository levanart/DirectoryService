using DirectoryService.Application.Locations;
using DirectoryService.Contracts.Locations;
using DirectoryService.Presentation.Extensions;
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
        var result = await _service.CreateAsync(request, cancellationToken);
        if (result.IsFailure)
            return result.Error.ToResponse();
        
        return Ok(result.Value);
    }
}