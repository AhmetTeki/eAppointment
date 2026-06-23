using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.GetAllDoctor;

internal sealed class GetAllDoctorQueryHandler(IDoctorRepository _repository) : IRequestHandler<GetAllDoctorQuery, Result<List<Doctor>>>
{
    public async Task<Result<List<Doctor>>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
    {
        List<Doctor> doctors = await _repository.GetAll().OrderBy(p => p.Department).ToListAsync(cancellationToken: cancellationToken);
        return doctors;
    }
}