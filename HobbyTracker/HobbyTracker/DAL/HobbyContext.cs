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
        public DbSet<User> Users { get; set; }
        public DbSet<Collection> Collections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<HobbyTracker.Models.Genre> Genres { get; set; }
    }
}