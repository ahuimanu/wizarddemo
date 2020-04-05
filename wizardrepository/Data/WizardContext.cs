using System;
using Microsoft.EntityFrameworkCore;

namespace wizardrepository.Data
{
    public class WizardContext : DbContext
    {
        public WizardContext(DbContextOptions<WizardContext> options) : base(options)
        {
        }

        public DbSet<Disposition> Dispositions { get; set; }        
    }
}