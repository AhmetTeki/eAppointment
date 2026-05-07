using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrasracture.Configurations;

internal class DoctorConfiguration: IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(x => x.FirstName).HasColumnType("varchar(50)");
        builder.Property(x => x.LastName).HasColumnType("varchar(50)");
    }
}