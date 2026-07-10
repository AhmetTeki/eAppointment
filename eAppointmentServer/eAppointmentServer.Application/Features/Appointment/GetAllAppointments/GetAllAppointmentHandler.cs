using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.GetAllAppointments;

public class GetAllAppointmentHandler(IAppointmentRepository _repository)
    : IRequestHandler<GetAllAppointmentsQuery, Result<List<GetAllAppointmentsResponse>>>
{
    public async Task<Result<List<GetAllAppointmentsResponse>>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var appointment = await _repository.Where(d => d.DoctorId == request.DoctorId).Include(p=>p.Patient).ToListAsync(cancellationToken);

        var response = appointment.Select(s => new GetAllAppointmentsResponse(s.Id,s.StartDate,s.EndDate,s.Patient!.FullName,s.Patient)).ToList();
        
        return response;
    }
}