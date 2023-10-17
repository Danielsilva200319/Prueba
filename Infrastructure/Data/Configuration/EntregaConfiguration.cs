using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EntregaConfiguration : IEntityTypeConfiguration<Entrega>
    {
        public void Configure(EntityTypeBuilder<Entrega> builder)
        {
            builder.ToTable("Entrega");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.Citas)
            .WithMany(p => p.Entregas)
            .HasForeignKey(p => p.IdCita);

            builder.HasOne(p => p.IntervalosHorarios)
            .WithMany(p => p.Entregas)
            .HasForeignKey(p => p.IdIntervaloHorario);

            builder.HasOne(p => p.Acciones)
            .WithMany(p => p.Entregas)
            .HasForeignKey(p => p.IdAccion);

            builder.HasOne(p => p.EstadosSolicitudes)
            .WithMany(p => p.Entregas)
            .HasForeignKey(p => p.IdEstadoSolicitud);

            builder.Property(p => p.HoraCita)
            .HasColumnType("time");

            builder.Property(p => p.NumeroEntrega)
            .IsRequired()
            .HasMaxLength(45);

            builder.Property(p => p.Cliente)
            .IsRequired()
            .HasMaxLength(45);

            builder.Property(p => p.Origen)
            .IsRequired()
            .HasMaxLength(45);

            builder.Property(p => p.Destino)
            .IsRequired()
            .HasMaxLength(45);

            builder.Property(p => p.CargaPrevista)
            .HasColumnType("date");

            builder.Property(p => p.EntregaPrevista)
            .HasColumnType("date");
        }
    }
}