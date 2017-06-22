using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikesShop.DAL.Models
{
    public class Bicycle
    {
        public int Id { get; set; }

        [Range(1950, 2018)]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public int? FrameMaterialId { get; set; }
        public virtual FrameMaterial FrameMaterial { get; set; }

        public int? ForkId { get; set; }
        public virtual Fork Fork { get; set; }

        public int? SizeId { get; set; }
        public virtual BicycleSize Size { get; set; }

        public virtual List<BicycleColor> Colors { get; set; }
      
    }
}