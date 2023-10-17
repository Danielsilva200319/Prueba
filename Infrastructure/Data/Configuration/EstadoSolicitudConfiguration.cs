using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EstadoSolicitudConfiguration : IEntityTypeConfiguration<EstadoSolicitud> 
    {
        public void Configure(EntityTypeBuilder<EstadoSolicitud> builder)
        {
            builder.ToTable("EstadoSolicitud");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.NombreEstado)
            .IsRequired()
            .HasMaxLength(45);
        }
    }
}