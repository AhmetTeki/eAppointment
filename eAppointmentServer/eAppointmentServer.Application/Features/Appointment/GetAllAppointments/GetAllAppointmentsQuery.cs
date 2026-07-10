using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.GetAllAppointments;

public sealed record GetAllAppointmentsQuery(Guid DoctorId):IRequest<Result<List<GetAllAppointmentsResponse>>>;