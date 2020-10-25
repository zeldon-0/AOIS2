using AOIS2.Core.Domain.Models.JoinModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Data.Context.Configurations.JoinEntities
{
    public class KanjiWithReadingRadicalConfiguration : IEntityTypeConfiguration<KanjiWithReadingRadical>
    {
        public void Configure(EntityTypeBuilder<KanjiWithReadingRadical> builder)
        {
            builder.HasKey(kr => 
                new { kr.KanjiWithReadingId, kr.RadicalId }
            );

            builder.HasOne(kr => kr.KanjiWithReading)
                .WithMany(k => k.KanjiWithReadingRadicals)
                .HasForeignKey(kr => kr.KanjiWithReadingId);

            builder.HasOne(kr => kr.Radical)
                .WithMany(k => k.KanjiWithReadingRadicals)
                .HasForeignKey(kr => kr.RadicalId);
        }
    }
}
