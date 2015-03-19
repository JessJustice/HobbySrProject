using Hobo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Hobo.DAL
{
    public class HoboContext : DbContext

    {  
        public HoboContext() : base("HoboContext")
        {
        }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}