using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BikesShop.DAL.Entities;

namespace BikesShop.DAL.EF
{
    public class BicycleContext : DbContext
    {
       
        public DbSet<BicycleEntity> Bicycles { get; set; }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<GenderEntity> Genders { get; set; }
        public DbSet<FrameMaterialEntity> FrameMaterials { get; set; }
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

            modelBuilder.Entity<BicycleEntity>().HasMany(b => b.Colors);
        }

    }
}