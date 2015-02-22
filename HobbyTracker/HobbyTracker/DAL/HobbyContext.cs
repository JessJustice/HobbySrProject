using HobbyTracker.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HobbyTracker.DAL
{
    public class HobbyContext : DbContext
    {
        public HobbyContext() : base( "HobbyContex")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}