using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Requests
{
    public class CarOfferUpdateRequestModel
    {

        [Required]
        public int Id { get; set; }
        public string? Make { get; set; }

        public string? Model { get; set; }

        [Range(0, 10000)]
        public int? AvailableStock { get; set; }

        public int? UnitPrice { get; set; }


    }
}
