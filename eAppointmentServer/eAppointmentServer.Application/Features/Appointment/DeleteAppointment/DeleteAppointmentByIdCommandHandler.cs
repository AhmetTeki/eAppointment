using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.DeleteAppointment;

public class DeleteAppointmentByIdCommandHandler(IAppointmentRepository _repository, IUnitOfWork _uow): IRequestHandler<DeleteAppointmentByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Appointment? appointment = await _repository.GetByExpressionAsync(x => x.Id == request.Id, cancellationToken);
        if (appointment is null)
        {
            return Result<string>.Failure("Appointment not found");
        }
        if (appointment.IsCompleted)
        {
            return Result<string>.Failure("Appointment not found");
        }
        
        _repository.Delete(appointment);
        await _uow.SaveChangesAsync(cancellationToken);
        return "Success";
    }
}