using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrasracture.Configurations;

internal class PatientConfiguration: IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(x => x.FirstName).HasColumnType("varchar(50)");
        builder.Property(x => x.LastName).HasColumnType("varchar(50)");
        builder.Property(x => x.City).HasColumnType("varchar(50)");
        builder.Property(x => x.Town).HasColumnType("varchar(50)");
        builder.Property(x => x.FullAddress).HasColumnType("varchar(400)");
        builder.Property(x => x.IdentityNumber).HasColumnType("varchar(11)");
        builder.HasIndex(x => x.IdentityNumber).IsUnique();
    }
}