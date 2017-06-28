﻿using System.Collections.Generic;
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

        public int? BrandId { get; set; }
        public virtual BrandEntity Brand { get; set; }

        public int? GenderId { get; set; }
        public virtual GenderEntity Gender { get; set; }

        public int? FrameMaterialId { get; set; }
        public virtual FrameMaterialEntity FrameMaterial { get; set; }

        public int? ForkId { get; set; }
        public virtual ForkEntity Fork { get; set; }

        public int? SizeId { get; set; }
        public virtual BicycleSizeEntity Size { get; set; }

        public virtual List<BicycleColorEntity> Colors { get; set; }
      
    }
}