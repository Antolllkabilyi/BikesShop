using System.ComponentModel.DataAnnotations;

namespace BikesShop.Models
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BicycleId { get; set; }
        public virtual BicycleViewModel Bicycle { get; set; }

        public bool IsPaid { get; set; }

    }
}
