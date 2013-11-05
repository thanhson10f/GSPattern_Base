using System.Data.Entity;
using GSP.Model.Entities;

namespace GSP.Data
{
    public class GSPDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            //modelBuilder.Configurations.Add(new CategoryConfiguration());
            //modelBuilder.Configurations.Add(new ExpenseConfiguration());
        }

    }
}
