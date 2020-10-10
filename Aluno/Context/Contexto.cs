using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Professor.Models;

namespace Professor.Context
{
    public class Contexto : DbContext
    {
        public DbSet<ProfessorModel> Professor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }        
    }
}

