using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BicicletaWEB.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ApplicationDBContext")
        {
        }

        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<VentaDetalles2> VentaDetalles2 { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>()
                .Property(e => e.nombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Precio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Ventas>()
                .Property(e => e.precioTotal)
                .HasPrecision(3, 0);
        }
    }
}
