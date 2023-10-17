using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CitaConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("Cita");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Citas)
            .HasColumnType("date");

            builder.HasOne(p => p.IntervaloHorario) // Decimos que en el IntervaloHorario Agregamos de uno a muchos en Citas
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.IdIntervaloHorario); // Aquí ponemos que queremos el Id del IntervaloHorario en uno a muchos.
        }
    }
}