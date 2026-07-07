using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.DeletePatientById;

public class DeletePatientByIdCommandHandler(IPatientRepository _repository, IUnitOfWork _uow):IRequestHandler<DeletePatientByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeletePatientByIdCommand request, CancellationToken cancellationToken)
    {
        Patient? patient = await _repository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (patient is null)
        {
            return Result<string>.Failure("Patient NOT FOUND");
        }
        
        _repository.Delete(patient);
        await _uow.SaveChangesAsync(cancellationToken);
        
        return "Success";
    }
}