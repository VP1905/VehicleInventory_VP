using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Entites;

namespace VehicleInventory.Infrastructure_VP.Data
{
    // This class is responsible for database access
    public class InventoryDbContext : DbContext
    {
        // Creates a new instance of InventoryDbContext using the provided database configuration options.
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(entity =>
            {
                // Map Vehicle aggregate to VP_Vehicle table
                entity.ToTable("VP_Vehicle");

                // Configure primary key
                entity.HasKey(v => v.Id);

                // VehicleCode is required and has a max length
                entity.Property(v => v.VehicleCode)
                       .IsRequired()
                       .HasMaxLength(50);

                // Location identifier
                entity.Property(v => v.LocationId)
                     .IsRequired();

                // Store VehicleType enum as an integer in the database
                entity.Property(v => v.VehicleType)
                      .HasConversion<int>()
                      .IsRequired();

                // Store VehicleStatus enum as an integer in the database
                entity.Property(v => v.Status)
                      .HasConversion<int>()
                      .IsRequired();

               
            });
        }
    }
}
