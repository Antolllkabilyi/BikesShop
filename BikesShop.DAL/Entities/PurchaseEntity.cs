using System.ComponentModel.DataAnnotations;

namespace BikesShop.DAL.Entities
{
    public class PurchaseEntity
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BicycleId { get; set; }
        public virtual BicycleEntity Bicycle { get; set; }

        public bool IsPaid { get; set; }

    }
}
