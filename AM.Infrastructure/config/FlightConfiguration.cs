using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.config
{
    public class FlightConfiguration:IEntityTypeConfiguration<Flight>
    {
        void IEntityTypeConfiguration<Flight>.Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("MyFlight");
            builder.HasKey(f => f.FlightId);
            builder.HasMany(f => f.Passengers).WithMany(f => f.Flights).UsingEntity(f => f.ToTable("FlightPassengers"));
            builder.HasOne(f => f.plane).WithMany(f=>f.Flights).HasForeignKey(f=> f.PlaneId).OnDelete(DeleteBehavior.SetNull);  
           
        }


    }
}
