using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BikesShop.DAL.Entities;

namespace BikesShop.DAL.EF
{
    public class BicycleContext : DbContext
    {
        public DbSet<BicycleEntity> Bicycles { get; set; }
        public DbSet<BicycleTypeEntity> Types { get; set; }
        public DbSet<BicycleSizeEntity> BicycleSize { get; set; }
        public DbSet<BicycleColorEntity> BicycleColors { get; set; }
        public DbSet<ForkEntity> Forks { get; set; }

        public BicycleContext(string connectionString) : base(connectionString)
        {
        }

        public BicycleContext() : base("name=BicycleContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}