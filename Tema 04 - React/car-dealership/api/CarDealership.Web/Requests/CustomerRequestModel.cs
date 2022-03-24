using System.ComponentModel.DataAnnotations;

namespace CarDealership.Web.Requests
{
    public class CustomerRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
