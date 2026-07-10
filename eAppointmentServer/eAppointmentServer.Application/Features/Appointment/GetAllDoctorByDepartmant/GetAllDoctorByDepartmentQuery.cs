using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.GetAllDoctorByDepartmant;

public sealed record GetAllDoctorByDepartmentQuery(int DepartmentValue): IRequest<Result<List<Doctor>>>;