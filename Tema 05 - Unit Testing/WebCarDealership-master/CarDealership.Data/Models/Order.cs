using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CarOfferId { get; set; }

        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public decimal OrderAmount { get; set; }

        public Customer Customer { get; set; }

        public CarOffer CarOffer { get; set; }
    }
}
