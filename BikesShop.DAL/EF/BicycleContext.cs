using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BikesShop.DAL.Entities;

namespace BikesShop.DAL.EF
{
    public class BicycleContext : DbContext
    {
       
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<FrameMaterial> FrameMaterials { get; set; }
        public DbSet<BicycleSize> BicycleSize { get; set; }
        public DbSet<BicycleColor> BicycleColors { get; set; }
        public DbSet<Fork> Forks { get; set; }

        public BicycleContext(string connectionString) : base(connectionString)
        {
        }

        public BicycleContext() : base("name=BicycleContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Bicycle>().HasMany(b => b.Colors);
        }

    }
}