using eAppointmentServer.Application.Features.Appointment.CreateAppointment;
using eAppointmentServer.Application.Features.Appointment.GetAllAppointments;
using eAppointmentServer.Application.Features.Appointment.GetAllDoctorByDepartmant;
using eAppointmentServer.Application.Features.Appointment.GetPatientByIdentityNumber;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AppointmentsController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetDoctorsByDepartment(GetAllDoctorByDepartmentQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAllByDoctorId(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetPatientByIdentityNumber(GetPatientByIdentityNumberQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    
}