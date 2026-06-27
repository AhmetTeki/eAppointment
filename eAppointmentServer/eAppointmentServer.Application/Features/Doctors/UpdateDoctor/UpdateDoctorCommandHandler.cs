using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.UpdateDoctor;

internal sealed class UpdateDoctorCommandHandler(IDoctorRepository _repository, IMapper _mapper, IUnitOfWork _uow) : IRequestHandler<UpdateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor? doctor = await _repository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        if (doctor is null)
        {
            return Result<string>.Failure("Doctor not found");
        }
        
        _mapper.Map(request,doctor);
        _repository.Update(doctor);
        await _uow.SaveChangesAsync(cancellationToken);
        return "Succes";
    }
}