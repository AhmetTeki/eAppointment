using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.CreateDoctor;

internal sealed class CreateDoctorCommandHandler(IDoctorRepository _repository, IUnitOfWork _uow, IMapper mapper)
    : IRequestHandler<CreateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor doctor = mapper.Map<Doctor>(request);

        await _repository.AddAsync(doctor, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        return "Success";
    }
}