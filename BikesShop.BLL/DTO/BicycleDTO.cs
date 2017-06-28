using System.Collections.Generic;
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

        public int? BrandId { get; set; }
        public virtual BrandDTO Brand { get; set; }

        public int? GenderId { get; set; }
        public virtual GenderDTO Gender { get; set; }

        public int? FrameMaterialId { get; set; }
        public virtual FrameMaterialDTO FrameMaterial { get; set; }

        public int? ForkId { get; set; }
        public virtual ForkDTO Fork { get; set; }

        public int? SizeId { get; set; }
        public virtual BicycleSizeDTO Size { get; set; }

        public virtual List<BicycleColorDTO> Colors { get; set; }
      
    }
}