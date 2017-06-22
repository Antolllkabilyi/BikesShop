using System.Collections.Generic;
using BikesShop.DAL.Models;


namespace BikesShop
{
    public class BicyclesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BicycleContext>
    {
        protected override void Seed(BicycleContext context)
        {
            var brands = new List<Brand>
            {
                new Brand{Name = "Fuji"},
                new Brand{Name = "Breezer"},
                new Brand{Name = "Marin Bicycles"},
                new Brand{Name = "Diamondback"}
            };
            brands.ForEach(s => context.Brands.Add(s));
            context.SaveChanges();

            var genders = new List<Gender>
            {
                new Gender{Name = "Man"},
                new Gender{Name = "Boys"},
                new Gender{Name = "Woman"},
                new Gender{Name = "Girl"},
                new Gender{Name = "Unisex"},
            };

            genders.ForEach(s => context.Genders.Add(s));
            context.SaveChanges();

            var frameMaterials = new List<FrameMaterial>
            {
                new FrameMaterial{Material = "Steel"},
                new FrameMaterial{Material = "Aluminum"},
                new FrameMaterial{Material = "Carbon"},
            };

            frameMaterials.ForEach(s => context.FrameMaterials.Add(s));
            context.SaveChanges();


            var colors = new List<BicycleColor>
            {
                new BicycleColor{Name="Green"},
                new BicycleColor{Name="Red"},
                new BicycleColor{Name="Blue"},
                new BicycleColor{Name="White"},
                new BicycleColor{Name="Black"},
                new BicycleColor{Name="Yellow"},
            };

            colors.ForEach(s => context.BicycleColors.Add(s));
            context.SaveChanges();

            var forks = new List<Fork>
            {
                new Fork{Name = "HY-FK-AL02", ForkBrand = "HY", ForkType = "RockShox"},
                new Fork{Name = "XCM", ForkBrand = "SR Suntour", ForkType = "Suspension"},
                new Fork{Name = "MLH-3", ForkBrand = "Spartan", ForkType = "Fox"},
            };
            forks.ForEach(s => context.Forks.Add(s));
            context.SaveChanges();

            var sizes = new List<BicycleSize>
            {
                new BicycleSize{Name = "S" , Size = 11.5},
                new BicycleSize{Name = "M" , Size = 16},
                new BicycleSize{Name = "L" , Size = 19.5},
                new BicycleSize{Name = "XL" , Size = 21}
            };

            sizes.ForEach(s => context.BicycleSize.Add(s));
            context.SaveChanges();

            var bicycles = new List<Bicycle>
            {
                new Bicycle
                {
                    ModelYear = 2016,
                    Price = 15000,
                    BrandId = 1,
                    GenderId = 2,
                    FrameMaterialId = 3,
                    ForkId = 1,
                    SizeId = 2,
                    Colors = new List<BicycleColor>
                    {
                        colors.Find(c=>c.Id==1),
                        colors.Find(c=>c.Id==2),
                    }
                },

                new Bicycle
                {
                    ModelYear = 2017,
                    Price = 17000,
                    BrandId = 2,
                    GenderId = 4,
                    FrameMaterialId = 2,
                    ForkId = 2,
                    SizeId = 4,
                    Colors = new List<BicycleColor>
                    {
                        colors.Find(c=>c.Id==3)
                    }
                }
            };
            bicycles.ForEach(s => context.Bicycles.Add(s));
            context.SaveChanges();


        }
    }
}