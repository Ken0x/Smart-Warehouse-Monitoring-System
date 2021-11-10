using MasterRad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRad.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Border> Borders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Border>()
                .HasMany(m => m.Measurements)
                .WithOne(b => b.Border);

            modelBuilder.Entity<Border>()
                .HasOne(s => s.Sector)
                .WithMany(b => b.Border)
                .HasForeignKey(b => b.SectorsId);

            modelBuilder.Entity<Border>()
                .HasOne(w => w.Warehouse)
                .WithMany(b => b.Border)
                .HasForeignKey(b => b.WarehousesId);

        }
    }
}

