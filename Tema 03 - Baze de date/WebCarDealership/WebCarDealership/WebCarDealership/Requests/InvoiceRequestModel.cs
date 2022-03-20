using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Requests
{
    public class InvoiceRequestModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }
    }
}
