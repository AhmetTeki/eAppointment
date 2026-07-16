using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.CreateAppointment;

public class CreateAppointmentCommandHandler(IAppointmentRepository _repository, IUnitOfWork _uow, IPatientRepository _patientRepository): IRequestHandler<CreateAppointmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        Patient patient = new();
        if (request.patientId is null)
        {
            patient= new()
            {
                FirstName = request.firstName,
                LastName = request.lastName,
                IdentityNumber =  request.identityNumber,
                City =  request.city,
                FullAddress =  request.fullAddress,
                Town = request.town
            };
            await _patientRepository.AddAsync(patient, cancellationToken);
        }

        Domain.Entities.Appointment appointment = new()
        {
            DoctorId=request.DoctorId,
            PatientId = request.patientId ?? patient.Id,
            StartDate =Convert.ToDateTime(request.startDate)  ,
            EndDate = Convert.ToDateTime(request.endDate) ,
            IsCompleted = false
        };
        await _repository.AddAsync(appointment, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        
        return "Success";
    }
}