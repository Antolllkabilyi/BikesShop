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

        public int? BrandId { get; set; }
        public virtual BrandViewModel Brand { get; set; }

        public int? GenderId { get; set; }
        public virtual GenderViewModel Gender { get; set; }

        public int? FrameMaterialId { get; set; }
        public virtual FrameViewModel FrameMaterial { get; set; }

        public int? ForkId { get; set; }
        public virtual ForkViewModel Fork { get; set; }

        public int? SizeId { get; set; }
        public virtual BicycleSizeViewModel Size { get; set; }

        public virtual List<BicycleColorViewModel> Colors { get; set; }
      
    }
}