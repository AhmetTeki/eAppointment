using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.GetAllDoctorByDepartmant;

public class GetAllDoctorByDepartmentQueryHandler(IDoctorRepository _repository)
    : IRequestHandler<GetAllDoctorByDepartmentQuery, Result<List<Doctor>>>
{
    public async Task<Result<List<Doctor>>> Handle(GetAllDoctorByDepartmentQuery request, CancellationToken cancellationToken)
    {
        List<Doctor> doctors = await _repository
            .Where(x => x.Department == request.DepartmentValue)
            .OrderBy(n => n.FirstName)
            .ToListAsync(cancellationToken);

        return doctors;
    }
}