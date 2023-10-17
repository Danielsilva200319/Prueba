using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class AccionConfiguration : IEntityTypeConfiguration<Accion> // Le colocamos implementar interfas para poder hacer la tabla
    {
        public void Configure(EntityTypeBuilder<Accion> builder)
        {
            builder.ToTable("Accion"); // Para colocar el nombre de la Tabla en la base de datos.

            builder.HasKey(e => e.Id); // Para llamar el Id.
            builder.Property(e => e.Id); // Para colocar el Id en la base de datos.

            builder.Property(p => p.NombreAccion) // para colocar el string o int que queremos.
            .IsRequired() // Para decirle que es requerido tener ese elemento.
            .HasMaxLength(45); // Para decirle hasta que longitud esta permitido.
        }
    }
}