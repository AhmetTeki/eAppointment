using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.DeleteDoctorById;

public class DeleteDoctorByIdCommandHandler(IDoctorRepository _repository, IUnitOfWork _uow):IRequestHandler<DeleteDoctorByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
    {
        Doctor? doctor = await _repository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (doctor is null)
        {
            return Result<string>.Failure("DOCTOR NOT FOUND");
        }
        
        _repository.Delete(doctor);
        await _uow.SaveChangesAsync(cancellationToken);
        
        return "Success";
    }
}