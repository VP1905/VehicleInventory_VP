using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain_VP.Entites;

namespace VehicleInventory.Infrastructure_VP.Data
{
    public class VehicleInventoryDbContext : DbContext
    {
        public VehicleInventoryDbContext(DbContextOptions<VehicleInventoryDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("VP_Vehicle");

                entity.HasKey(v => v.Id);

                entity.Property(v => v.Make)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(v => v.Model)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(v => v.VehicleType)
                      .HasConversion<int>()
                      .HasColumnName("VehicleTypeId");

                entity.Property(v => v.Status)
                      .HasConversion<int>()
                      .HasColumnName("VehicleStatusId");

                entity.Property(v => v.LocationId)
                      .HasColumnName("VehicleLocationId");
            });
        }
    }
}
