using System.ComponentModel.DataAnnotations;

namespace CarDealership.Web.Requests
{
    public class CarOfferRequestModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(0, 10000)]
        public int AvailableStock { get; set; }

        public decimal UnitPrice { get; set; }

        public string Image { get; set; }
    }
}
