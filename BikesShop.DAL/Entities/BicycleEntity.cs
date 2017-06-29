using System.ComponentModel.DataAnnotations;

namespace BikesShop.DAL.Entities
{
    public class BicycleEntity
    {
        public int Id { get; set; }

        [Range(1950, 2018)]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public int? TypeId { get; set; }
        public virtual BicycleTypeEntity Type { get; set; }

        public int? ForkId { get; set; }
        public virtual ForkEntity Fork { get; set; }

        public int? SizeId { get; set; }
        public virtual BicycleSizeEntity Size { get; set; }

        public int? ColorId { get; set; }
        public virtual BicycleColorEntity Color { get; set; }
      
    }
}