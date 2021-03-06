﻿using AOIS2.Core.Domain.Models.Kanji;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Data.Context.Configurations.Entities
{
    public class KanjiWithWordsConfiguration: IEntityTypeConfiguration<KanjiWithWords>
    {
        public void Configure(EntityTypeBuilder<KanjiWithWords> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(k => k.Kanji)
                .HasMaxLength(1)
                .IsRequired();
            builder.Property(r => r.TaughtInGrade)
                .IsRequired();
            builder.Property(r => r.Strokes)
                .IsRequired();
            builder.Property(r => r.Words)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
