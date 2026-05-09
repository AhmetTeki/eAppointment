using eAppointmentServer.Application.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}