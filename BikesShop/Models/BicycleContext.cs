using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BikesShop.Models
{
    public class BicycleContext : DbContext
    {

        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<FrameMaterial> FrameMaterials { get; set; }
        public DbSet<BicycleColor> BicycleColors { get; set; }
        public DbSet<Fork> Forks { get; set; }
    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Bicycle>()
                .HasMany(b => b.Colors);
        }
       
    }
}