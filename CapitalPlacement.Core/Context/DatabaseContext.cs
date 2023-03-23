using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Models.Stages;
using Microsoft.EntityFrameworkCore;
using System;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stage>().ToContainer("Stages").HasPartitionKey(x => x.Id);
            modelBuilder.Entity<Program>().ToContainer("Programs").HasPartitionKey(x => x.Id);
            modelBuilder.Entity<Application>().ToContainer("Applications").HasPartitionKey(x => x.Id);
            modelBuilder.Entity<AdditionalQuestion>().ToContainer("Questions").HasPartitionKey(x => x.Id);
               
        }


        public DbSet<Program> Programs { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<AdditionalQuestion> Questions { get; set; }
        public DbSet<Stage> Stages { get; set; }

    }
}
