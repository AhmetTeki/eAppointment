using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.CreateAppointment;

public sealed record CreateAppointmentCommand(string startDate, string endDate, Guid? patientId,Guid DoctorId ,string firstName, string lastName, string identityNumber, string city, string town, string fullAddress): IRequest<Result<string>>;