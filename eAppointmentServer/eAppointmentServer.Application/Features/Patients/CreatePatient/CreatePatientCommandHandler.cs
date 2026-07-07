using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.CreatePatient;

internal sealed class CreatePatientCommandHandler(IPatientRepository _repository, IUnitOfWork _uow, IMapper mapper)
    : IRequestHandler<CreatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        if (await _repository.AnyAsync(p => p.IdentityNumber == request.IdentityNumber, cancellationToken))
        {
            return Result<string>.Failure("Already Recorded");
        }
        
        Patient patient = mapper.Map<Patient>(request);

        await _repository.AddAsync(patient, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        return "Success";
    }
}