using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class IntervaloHorarioConfiguration : IEntityTypeConfiguration<IntervaloHorario>
    {
        public void Configure(EntityTypeBuilder<IntervaloHorario> builder)
        {
            builder.ToTable("IntervaloHorario");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.IntervalosHorarios)
            .IsRequired()
            .HasMaxLength(45);

            builder.Property(p => p.NumerosVehiculos)
            .HasColumnType("int");
        }
    }
}