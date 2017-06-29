using System.ComponentModel.DataAnnotations;

namespace BikesShop.BLL.DTO
{
    public class BicycleDTO
    {
        public int Id { get; set; }

        [Range(1950, 2018)]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public int? TypeId { get; set; }
        public virtual BicycleTypeDTO Type { get; set; }

        public int? ForkId { get; set; }
        public virtual ForkDTO Fork { get; set; }

        public int? SizeId { get; set; }
        public virtual BicycleSizeDTO Size { get; set; }

        public int? ColorId { get; set; }
        public virtual BicycleColorDTO Color { get; set; }
      
    }
}