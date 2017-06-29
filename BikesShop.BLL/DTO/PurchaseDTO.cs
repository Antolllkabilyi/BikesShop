using System.ComponentModel.DataAnnotations;

namespace BikesShop.BLL.DTO
{
    public class PurchaseDTO
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BicycleId { get; set; }
        public virtual BicycleDTO Bicycle { get; set; }

        public bool IsPaid { get; set; }

    }
}
