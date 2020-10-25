using AOIS2.Core.Domain.Models.JoinModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Data.Context.Configurations.JoinEntities
{
    public class KanjiWithReadingAndWordsRadicalConfiguration : IEntityTypeConfiguration<KanjiWithReadingAndWordsRadical>
    {
        public void Configure(EntityTypeBuilder<KanjiWithReadingAndWordsRadical> builder)
        {
            builder.HasKey(kr => 
                new { kr.KanjiWithReadingAndWordsId, kr.RadicalId }
            );

            builder.HasOne(kr => kr.KanjiWithReadingAndWords)
                .WithMany(k => k.KanjiWithReadingAndWordsRadicals)
                .HasForeignKey(kr => kr.KanjiWithReadingAndWordsId);

            builder.HasOne(kr => kr.Radical)
                .WithMany(k => k.KanjiWithReadingAndWordsRadicals)
                .HasForeignKey(kr => kr.RadicalId);
        }
    }
}
