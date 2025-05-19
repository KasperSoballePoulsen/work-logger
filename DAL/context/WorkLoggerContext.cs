using DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.context
{
    public class WorkLoggerContext : DbContext
    {
        public WorkLoggerContext() : base("WorkLoggerContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Afdeling> Afdelinger { get; set; }
        public DbSet<Medarbejder> Medarbejdere { get; set; }
        public DbSet<Sag> Sager { get; set; }
        public DbSet<Tidsregistrering> Tidsregistreringer { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
