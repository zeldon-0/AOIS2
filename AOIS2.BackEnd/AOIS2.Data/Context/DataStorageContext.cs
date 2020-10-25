using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AOIS2.Core.Domain.Models.JoinModels;
using AOIS2.Core.Domain.Models.Radicals;
using AOIS2.Core.Domain.Models.Kanji;
using AOIS2.Data.Context.Configurations.Entities;
using AOIS2.Data.Context.Configurations.JoinEntities;

namespace AOIS2.Data.Context
{
    public class DataStorageContext : DbContext
    {
        public DbSet<Radical> Radicals { get; set; }
        public DbSet<KanjiWithReading> KanjisWithReading { get; set; }
        public DbSet<KanjiWithWords> KanjisWithWords { get; set; }
        public DbSet<KanjiWithReadingAndWords> KanjisWithReadingAndWords { get; set; }
        public DataStorageContext(DbContextOptions<DataStorageContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DataStorageContext() : base()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RadicalConfiguration());
            modelBuilder.ApplyConfiguration(new KanjiWithReadingConfiguration());
            modelBuilder.ApplyConfiguration(new KanjiWithWordsConfiguration());
            modelBuilder.ApplyConfiguration(new KanjiWithReadingAndWordsConfiguration());
            modelBuilder.ApplyConfiguration(new KanjiWithReadingRadicalConfiguration());
            modelBuilder.ApplyConfiguration(new KanjiWithWordsRadicalConfiguration());
            modelBuilder.ApplyConfiguration(new KanjiWithReadingAndWordsRadicalConfiguration());
        }
    }
}
