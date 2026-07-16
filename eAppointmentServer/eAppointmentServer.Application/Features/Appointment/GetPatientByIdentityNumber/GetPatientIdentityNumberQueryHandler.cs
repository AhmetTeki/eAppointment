using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.GetPatientByIdentityNumber;

public class GetPatientIdentityNumberQueryHandler(IPatientRepository _repository): IRequestHandler<GetPatientByIdentityNumberQuery, Result<Patient>>
{
    public async Task<Result<Patient>> Handle(GetPatientByIdentityNumberQuery request, CancellationToken cancellationToken)
    {
        Patient? patient = await _repository.GetByExpressionAsync(p=>p.IdentityNumber == request.IdentityNumber, cancellationToken);
        return patient;
    }
}