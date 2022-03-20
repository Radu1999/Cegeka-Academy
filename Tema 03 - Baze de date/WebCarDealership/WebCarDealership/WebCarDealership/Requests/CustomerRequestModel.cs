using System.ComponentModel.DataAnnotations;
using CarDealership.Data.Models;

namespace WebCarDealership.Requests
{
    public class CustomerRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        public ICollection<Order>? Orders { get; set; }

        public int? Id { get; set; }
    }
}
