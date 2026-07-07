using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.GetAllPatient;

internal sealed class GetAllPatientQueryHandler(IPatientRepository _repository) : IRequestHandler<GetAllPatientQuery, Result<List<Patient>>>
{
    public async Task<Result<List<Patient>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
    {
        List<Patient> patients = await _repository.GetAll().OrderBy(x=>x.FirstName).ToListAsync(cancellationToken: cancellationToken);
        return patients;
    }
}