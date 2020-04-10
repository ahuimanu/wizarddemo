using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using wizarddata.Data;
using wizardrepository;
using wizardrepository.DependencyInjection;

namespace wizarddata.Data
{
    public class WizardContext : DbContext
    {
        public WizardContext(DbContextOptions<WizardContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }        

        public DbSet<Competency> Competencies { get; set;}
        public DbSet<Disposition> Dispositions { get; set; }

        public DbSet<CompetencyDispositions> CompetencyDispositions{get; set;}
        public DbSet<KnowledgeElement> KnowledgeElements { get; set;}
        public DbSet<SkillLevel> SkillLevels {get; set;}
        public DbSet<KSPair> KSPairs {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /* KNOWLEDGE ELEMENTS */
            //life-saving rerence: https://dotnetcultist.com/many-to-many-relationship-entity-framework-core/
            // modelBuilder.Entity<KnowledgeElement>()
            //             .HasMany(k => k.KSPairs)
            //             .WithOne(k => k.KnowledgeElement)
            //             .HasForeignKey(s => s.KnowledgeElementId);

            /* SKILL LEVELS */            
            //life-saving rerence: https://dotnetcultist.com/many-to-many-relationship-entity-framework-core/
            // modelBuilder.Entity<SkillLevel>()
            //             .HasMany(s => s.KSPairs)
            //             .WithOne(s => s.SkillLevel)
            //             .HasForeignKey(k => k.SkillLevelId);


            /* KS PAIRS */
            // modelBuilder.Entity<KSPair>(ksp => {
            //     ksp.HasKey(t => new {t.KnowledgeElementId, t.SkillLevelId});
            // });

            // modelBuilder.Entity<KSPair>( ksp => {
            //     ksp.HasOne(k => k.SkillLevel)
            //        .WithMany(k => k.KSPairs)
            //        .HasForeignKey(s => s.KnowledgeElementId);
            // });

            // modelBuilder.Entity<KSPair>( ksp => {
            //     ksp.HasOne(s => s.KnowledgeElement)
            //        .WithMany(s => s.KSPairs)
            //        .HasForeignKey(k => k.SkillLevelId);
            // });

            /* DISPOSITIONS */
            modelBuilder.Entity<Disposition>(entity =>
            {

            });      


            /* COMPETENCY DISPOSITIONS */
            // many to many: https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
            // modelBuilder.Entity<CompetencyDispositions>(cd => {
            //     cd.HasKey(t => new {t.CompetencyId, t.DispositionId});
            // });

            // modelBuilder.Entity<CompetencyDispositions>( cd => {
            //     cd.HasOne(d => d.Competency)
            //       .WithMany(c => c.CompetencyDispositions)
            //       .HasForeignKey(c => c.CompetencyId);
            // });

            // modelBuilder.Entity<CompetencyDispositions>( cd => {
            //     cd.HasOne(c => c.Disposition)
            //       .WithMany(d => d.CompetencyDispositions)
            //       .HasForeignKey(d => d.DispositionId);
            // });




            /* ATOMIC COMPETENCY */
            // modelBuilder.Entity<AtomicCompetency>(e => {
            //     e.HasBaseType<Competency>();
            //     // e.OwnsMany(d => d.Dispostions, a => 
            //     // {
            //     //     a.WithOwner().HasForeignKey("DispositionId");
            //     //     a.Property<int>("Id");
            //     //     a.HasKey("Id");
            //     // });
            //     e.HasData(                
            //         new AtomicCompetency{
            //             Id = 1,
            //             Name = "Competency A",
            //             Description = "Doing good things for A",
            //             Dispostions = new List<Disposition>() {
            //                 new Disposition {
            //                     Id = 4,
            //                     Name = "Proactiver",
            //                     Category = "Habits",
            //                     Discipline = "Information Systems",
            //                     Description = @"With Initiative (Nwokeji, Stachel, & " +
            //                                     "Holmes, 2019) / Self-Starter (Clear, 2017) " +
            //                                     "Shows independence. Ability to assess and " +
            //                                     "start activities independently without needing " +
            //                                     "to be told what to do. Willing to take the lead, " +
            //                                     "not waiting for others to start activities or wait " +
            //                                     "for instructions."                                

            //                 }
            //             },
            //         }
            //     );
            // });

            base.OnModelCreating(modelBuilder);
        }        
    }
}