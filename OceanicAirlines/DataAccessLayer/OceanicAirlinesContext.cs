﻿using OceanicAirlines.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OceanicAirlines.DataAccessLayer
{
    public class OceanicAirlinesContext : DbContext
    {
        public OceanicAirlinesContext() : base("db-oa-dk1") 
        {
            // Add connection strings
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Dimensions> Dimensions { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<TransportationMethod> TransportationMethods { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

    

            modelBuilder.Entity<Route>()
                    .HasRequired(m => m.Origin)
                    .WithMany(m => m.OriginCityRoutes)
                    .HasForeignKey(m => m.OriginID)
                    .WillCascadeOnDelete(false);


            modelBuilder.Entity<Route>()
                    .HasRequired(m => m.Destination)
                    .WithMany(m => m.DestinationCityRoutes)
                    .HasForeignKey(m => m.DestinationID)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parcel>()
                    .HasRequired(m => m.Origin)
                    .WithMany(m => m.OriginCityParcel)
                    .HasForeignKey(m => m.OriginID)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parcel>()
                    .HasRequired(m => m.Destination)
                    .WithMany(m => m.DestinationCityParcel)
                    .HasForeignKey(m => m.DestinationID)
                    .WillCascadeOnDelete(false);
        }
    }
}