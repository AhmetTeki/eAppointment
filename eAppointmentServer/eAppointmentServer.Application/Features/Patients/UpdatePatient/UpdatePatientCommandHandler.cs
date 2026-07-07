using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.UpdatePatient;

internal sealed class UpdatePatientCommandHandler(IPatientRepository _repository, IMapper _mapper, IUnitOfWork _uow) : IRequestHandler<UpdatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        Patient? patient = await _repository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        if (patient is null)
        {
            return Result<string>.Failure("Doctor not found");
        }
        
        _mapper.Map(request,patient);
        _repository.Update(patient);
        await _uow.SaveChangesAsync(cancellationToken);
        return "Succes";
    }
}