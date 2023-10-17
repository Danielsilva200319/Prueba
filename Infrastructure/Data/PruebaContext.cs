using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<EstadoSolicitud> EstadosSolicitudes { get; set; }
        public DbSet<IntervaloHorario> IntervalosHorarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}