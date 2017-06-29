using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikesShop.Models
{
    public class BicycleViewModel
    {
        public int Id { get; set; }

        [Range(1950, 2018)]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public int? TypeId { get; set; }
        public virtual BicycleTypeViewModel Type { get; set; }

        public int? ForkId { get; set; }
        public virtual ForkViewModel Fork { get; set; }

        public int? SizeId { get; set; }
        public virtual BicycleSizeViewModel Size { get; set; }

        public int? ColorId { get; set; }
        public virtual BicycleColorViewModel Color { get; set; }
      
    }
}