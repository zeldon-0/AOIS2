using AOIS2.Core.Domain.Models.Kanji;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Data.Context.Configurations.Entities
{
   public  class KanjiWithReadingConfiguration : IEntityTypeConfiguration<KanjiWithReading>
   {
        public void Configure(EntityTypeBuilder<KanjiWithReading> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(k => k.Kanji)
                .HasColumnType("nvarchar(4000)")
                .IsRequired();
            builder.Property(k => k.Reading)
                .HasColumnType("nvarchar(4000)")
                .IsRequired();

            builder.Property(r => r.JLPTLevel)
                .IsRequired();
        }
   }
}
