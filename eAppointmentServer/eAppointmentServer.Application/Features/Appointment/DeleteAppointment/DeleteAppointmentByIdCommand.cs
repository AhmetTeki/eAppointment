using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.DeleteAppointment;

public sealed record DeleteAppointmentByIdCommand(Guid Id): IRequest<Result<string>>;