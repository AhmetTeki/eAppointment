using eAppointmentServer.Domain.Entities;

namespace eAppointmentServer.Application.Features.Appointment.GetAllAppointments;

public sealed record GetAllAppointmentsResponse(Guid Id, DateTime StartDate, DateTime EndDate,string Title, Patient Patient);