using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.config
{


    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        void IEntityTypeConfiguration<Passenger>.Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(f => f.fullName, p =>
            {
                p.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(20).HasColumnType("varchar");
                p.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(20).HasColumnType("varchar");

            });
        }
    }
}
