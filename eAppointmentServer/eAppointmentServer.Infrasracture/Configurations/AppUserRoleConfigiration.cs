using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrasracture.Configurations;

public sealed class AppUserRoleConfigiration : IEntityTypeConfiguration<AppUserRole> 
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.HasKey(x => new { x.UserId, x.RoleId });
    }
}