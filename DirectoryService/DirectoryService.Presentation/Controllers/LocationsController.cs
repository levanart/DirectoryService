using DirectoryService.Application.Locations.CreateLocation;
using DirectoryService.Contracts.Locations;
using DirectoryService.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[Route("/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocation(
        [FromServices] CreateLocationHandler handler,
        [FromBody] CreateLocationDto request,
        CancellationToken cancellationToken)
    {
        var command = new CreateLocationCommand(request);
        
        var result = await handler.Handle(command, cancellationToken);
        if (result.IsFailure)
            return result.Error.ToResponse();
        
        return Ok(result.Value);
    }
}