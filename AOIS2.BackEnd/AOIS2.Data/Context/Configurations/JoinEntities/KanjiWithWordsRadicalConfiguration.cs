using AOIS2.Core.Domain.Models.JoinModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Data.Context.Configurations.JoinEntities
{
    public class KanjiWithWordsRadicalConfiguration: IEntityTypeConfiguration<KanjiWithWordsRadical>
    {
        public void Configure(EntityTypeBuilder<KanjiWithWordsRadical> builder)
        {
            builder.HasKey(kr => 
                new { kr.KanjiWithWordsId, kr.RadicalId }
            );

            builder.HasOne(kr => kr.KanjiWithWords)
                .WithMany(k => k.KanjiWithWordsRadicals)
                .HasForeignKey(kr => kr.KanjiWithWordsId);

            builder.HasOne(kr => kr.Radical)
                .WithMany(k => k.KanjiWithWordsRadicals)
                .HasForeignKey(kr => kr.RadicalId);
        }
    }
}
