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
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        void IEntityTypeConfiguration<Plane>.Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.ToTable("MyPlane");
            builder.HasKey(f => f.PlaneId);
            builder.Property(f => f.Capacity).HasColumnName("PlaneCapacity");

        }
    }
}
