using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(l => l.StreetAddress)
                 .IsRequired()  
                 .HasMaxLength(255); 

            
            builder.Property(l => l.PostalCode)
                 .HasMaxLength(20)
                 .IsRequired();
        }
    }
}
