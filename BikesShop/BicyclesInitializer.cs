using System.Collections.Generic;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BicycleColorViewModel = BikesShop.Models.BicycleColorViewModel;
using BicycleViewModel = BikesShop.Models.BicycleViewModel;
using BicycleSizeViewModel = BikesShop.Models.BicycleSizeViewModel;
using BrandViewModel = BikesShop.Models.BrandViewModel;
using ForkViewModel = BikesShop.Models.ForkViewModel;
using FrameViewModel = BikesShop.Models.FrameViewModel;
using GenderViewModel = BikesShop.Models.GenderViewModel;


namespace BikesShop
{
    public class BicyclesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BicycleContext>
    {
        protected override void Seed(BicycleContext context)
        {
            var brands = new List<BrandEntity>
            {
                new BrandEntity{Name = "Fuji"},
                new BrandEntity{Name = "Breezer"},
                new BrandEntity{Name = "Marin Bicycles"},
                new BrandEntity{Name = "Diamondback"}
            };
            brands.ForEach(s => context.Brands.Add(s));
            context.SaveChanges();

            var genders = new List<GenderEntity>
            {
                new GenderEntity{Name = "Man"},
                new GenderEntity{Name = "Boys"},
                new GenderEntity{Name = "Woman"},
                new GenderEntity{Name = "Girl"},
                new GenderEntity{Name = "Unisex"},
            };

            genders.ForEach(s => context.Genders.Add(s));
            context.SaveChanges();

            var frameMaterials = new List<FrameMaterialEntity>
            {
                new FrameMaterialEntity{Material = "Steel"},
                new FrameMaterialEntity{Material = "Aluminum"},
                new FrameMaterialEntity{Material = "Carbon"},
            };

            frameMaterials.ForEach(s => context.FrameMaterials.Add(s));
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
                    BrandId = 1,
                    GenderId = 2,
                    FrameMaterialId = 3,
                    ForkId = 1,
                    SizeId = 2,
                    Colors = new List<BicycleColorEntity>
                    {
                        colors.Find(c=>c.Id==1),
                        colors.Find(c=>c.Id==2),
                    }
                },

                new BicycleEntity
                {
                    ModelYear = 2017,
                    Price = 17000,
                    BrandId = 2,
                    GenderId = 4,
                    FrameMaterialId = 2,
                    ForkId = 2,
                    SizeId = 4,
                    Colors = new List<BicycleColorEntity>
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