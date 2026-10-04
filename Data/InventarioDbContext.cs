using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using InventarioPersonal.Models;

namespace InventarioPersonal.Data
{
    public class InventarioDbContext : DbContext
    {
        public DbSet<InventarioItem> Inventario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Usar la ruta absoluta del archivo sqlite o relativa a la ejecución
                string dbDirectory = @"/Users/winstonjimenez/Downloads/Iventario_personal";
                string dbPath = Path.Combine(dbDirectory, "inventario.db");

                if (!File.Exists(dbPath))
                {
                    dbPath = "inventario.db";
                }

                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventarioItem>(entity =>
            {
                entity.ToTable("inventario");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Categoria).HasColumnName("categoria").IsRequired();
                entity.Property(e => e.Item).HasColumnName("item").IsRequired();
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.Unidad).HasColumnName("unidad").IsRequired();
                entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            });
        }
    }
}
