using System.Collections.Generic;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;

namespace BikesShop
{
    public class BicyclesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BicycleContext>
    {
        protected override void Seed(BicycleContext context)
        {

            var type = new List<BicycleTypeEntity>
            {
                new BicycleTypeEntity{Name = "Road"},
                new BicycleTypeEntity{Name = "Mountain"},
                new BicycleTypeEntity{Name = "Cruiser"},
                new BicycleTypeEntity{Name = "Hybrid"},
                new BicycleTypeEntity{Name = "Fitness"},
            };

            type.ForEach(s => context.Types.Add(s));
            context.SaveChanges();

            var colors = new List<BicycleColorEntity>
            {
                new BicycleColorEntity{Name="Green"},
                new BicycleColorEntity{Name="Red"},
                new BicycleColorEntity{Name="Blue"},
                new BicycleColorEntity{Name="White"},
                new BicycleColorEntity{Name="Black"},
                new BicycleColorEntity{Name="Yellow"},
            };

            colors.ForEach(s => context.BicycleColors.Add(s));
            context.SaveChanges();

            var forks = new List<ForkEntity>
            {
                new ForkEntity{Name = "HY-FK-AL02", ForkBrand = "HY", ForkType = "RockShox"},
                new ForkEntity{Name = "XCM", ForkBrand = "SR Suntour", ForkType = "Suspension"},
                new ForkEntity{Name = "MLH-3", ForkBrand = "Spartan", ForkType = "Fox"},
            };
            forks.ForEach(s => context.Forks.Add(s));
            context.SaveChanges();

            var sizes = new List<BicycleSizeEntity>
            {
                new BicycleSizeEntity{Name = "S" , Size = 11.5},
                new BicycleSizeEntity{Name = "M" , Size = 16},
                new BicycleSizeEntity{Name = "L" , Size = 19.5},
                new BicycleSizeEntity{Name = "XL" , Size = 21}
            };

            sizes.ForEach(s => context.BicycleSize.Add(s));
            context.SaveChanges();

            var bicycles = new List<BicycleEntity>
            {
                new BicycleEntity
                {
                    ModelYear = 2016,
                    Price = 15000,
                    TypeId = 1,
                    ForkId = 1,
                    SizeId = 2,
                    ColorId = 5
                },

                new BicycleEntity
                {
                    ModelYear = 2017,
                    Price = 17000,
                    TypeId = 2,
                    ForkId = 2,
                    SizeId = 4,
                    ColorId = 2
                }
            };
            bicycles.ForEach(s => context.Bicycles.Add(s));
            context.SaveChanges();


        }
    }
}