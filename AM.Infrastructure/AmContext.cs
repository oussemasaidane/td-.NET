using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.config;

namespace AM.Infrastructure
{
    public class AmContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

            //modelBuilder.Entity<Passenger>().Property(f => f.FirstName)
            //    .HasColumnName("PassengerName")
            //    .HasMaxLength(50)
            //    .IsRequired()
            //    .HasColumnType("varchar");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(50);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<Double>().HavePrecision(2);
            //on n'a pas besoin de mettre .HaveColumnType("real") car pas default dans la base devient real
        }
        public DbSet <Flight> Flights { get; set; }
      public DbSet<Plane> Plane { get; set; }
      public DbSet<Passenger> passengers { get; set; }
      public DbSet<Traveller> travellers { get; set; }
      public DbSet<Staff> Staffs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source = (localdb)\mssqllocaldb;initial catalog = OussemaBase;integrated security = true ");
        }




    }
}
