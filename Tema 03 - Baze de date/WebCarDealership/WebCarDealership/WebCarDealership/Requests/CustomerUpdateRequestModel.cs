using System.ComponentModel.DataAnnotations;
using CarDealership.Data.Models;

namespace WebCarDealership.Requests
{
    public class CustomerUpdateRequestModel
    {   
        [Required]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public ICollection<Order>? Orders { get; set; }

        
    }
}
