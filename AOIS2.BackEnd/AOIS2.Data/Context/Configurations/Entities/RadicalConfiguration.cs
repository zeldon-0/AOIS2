using AOIS2.Core.Domain.Models.Radicals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Data.Context.Configurations.Entities
{
    public class RadicalConfiguration : IEntityTypeConfiguration<Radical>
    {
        public void Configure(EntityTypeBuilder<Radical> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Character)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(r => r.Strokes)
                .IsRequired();
        }
    }
}
