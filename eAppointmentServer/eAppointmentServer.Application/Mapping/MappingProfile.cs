using AutoMapper;
using eAppointmentServer.Application.Features.Doctors.CreateDoctor;
using eAppointmentServer.Application.Features.Doctors.UpdateDoctor;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;

namespace eAppointmentServer.Application.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommand,Doctor>().ForMember(member => member.Department, opt => opt.MapFrom(command => DepartmentEnum.FromValue(command.Department)));
        CreateMap<UpdateDoctorCommand,Doctor>().ForMember(member => member.Department, opt => opt.MapFrom(command => DepartmentEnum.FromValue(command.Department)));
    }
}