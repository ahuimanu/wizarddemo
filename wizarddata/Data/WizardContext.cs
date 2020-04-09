using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace wizarddata.Data
{
    public class WizardContext : DbContext
    {
        public WizardContext(DbContextOptions<WizardContext> options) : base(options)
        {
        }

        public DbSet<Competency> Competencies { get; set;}
        public DbSet<Disposition> Dispositions { get; set; }
        public DbSet<KnowledgeElement> KnowledgeElements { get; set;}
        public DbSet<SkillLevel> SkillLevels {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Competency>(entity =>
            {
                entity.HasData(
                        new AtomicCompetency{
                            Name = "Competency A",
                            Description = "Doing good things for A",
                            Dispostions = new List<Disposition>() {
                                new Disposition {
                                    Id = 4,
                                    Name = "Proactiver",
                                    Category = "Habits",
                                    Discipline = "Information Systems",
                                    Description = @"With Initiative (Nwokeji, Stachel, & " +
                                                    "Holmes, 2019) / Self-Starter (Clear, 2017) " +
                                                    "Shows independence. Ability to assess and " +
                                                    "start activities independently without needing " +
                                                    "to be told what to do. Willing to take the lead, " +
                                                    "not waiting for others to start activities or wait " +
                                                    "for instructions."                                

                                }
                            },
                            KSPairs =  new Dictionary<KnowledgeElement, SkillLevel>{
                                {
                                    new KnowledgeElement{
                                        Id = 1,
                                        Name = "Control Structures",
                                        Description = "selection, repetition, sequence",
                                        CartesianIndex = 1,
                                        SemioticIndex = 1,
                                        Etymology = "Programming"
                                    },
                                    new SkillLevel{
                                        Id = 1,
                                        Name = "Create",
                                        Description = "Put elements together to form a coherent whole; reorganize into a new pattern or structure",
                                        CartesianIndex = 6
                                    }
                                }
                            }
                        }
                    );
                }
            );

            /* DISPOSITIONS */
            modelBuilder.Entity<Disposition>(entity =>
            {
                entity.HasData(
                    new Disposition 
                    {
                        Id = 1,
                        Name = "Proactive",
                        Category = "Habits",
                        Discipline = "Information Systems",
                        Description = @"With Initiative (Nwokeji, Stachel, & " +
                                        "Holmes, 2019) / Self-Starter (Clear, 2017) " +
                                        "Shows independence. Ability to assess and " +
                                        "start activities independently without needing " +
                                        "to be told what to do. Willing to take the lead, " +
                                        "not waiting for others to start activities or wait " +
                                        "for instructions."

                    },
                    new Disposition 
                    {
                        Id = 2,
                        Name = "Purpose-Driven",
                        Category = "Qualities",
                        Discipline = "Information Systems",
                        Description = @"Purposefully engaged / Purposefulness " +
                                        "(Nwokeji et al., 2019), (Clear, 2017) " +
                                        "Goal-directed, intentionally acting and " +
                                        "committed to achieve organizational and " +
                                        "project goals. Reflects an attitude towards " +
                                        "the organizational goals served by decisions, " +
                                        "work or work products. e.g., Business acumen."

                    },
                    new Disposition 
                    {
                        Id = 3,
                        Name = "Self-Directed",
                        Category = "Qualities",
                        Discipline = "Information Systems",
                        Description = @"Self-motivated (Clear, 2017) / Self-Directed " +
                                        "(Nwokeji et al., 2019) Demonstrates determination " +
                                        "to sustain efforts to continue tasks. Direction " +
                                        "from others is not required to continue a task " +
                                        "toward its desired ends."
                    }
                );
            });

            base.OnModelCreating(modelBuilder);
        }        
    }
}