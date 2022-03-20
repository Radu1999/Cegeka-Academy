using Microsoft.AspNetCore.Mvc;
using WebCarDealership.Requests;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public InvoiceController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceRequestModel invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var dbModel = new Invoice
            {
                CustomerId = invoice.CustomerId,
                InvoiceDate = invoice.InvoiceDate,
                InvoiceNumber = invoice.InvoiceNumber,
            };

            dbModel.Amount = await CalculateAmount(dbModel);

            _dbContext.Invoices.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

        private async Task<decimal> CalculateAmount(Invoice invoice)
        {
            var customer = await _dbContext.Customers.Include(c => c.Orders).FirstAsync(c => c.Id == invoice.CustomerId);
            if(customer == null)
            {
                return 0;
            }
            decimal amount = 0;
            foreach(Order order in customer.Orders)
            {
                var offer = await _dbContext.CarOffers.FindAsync(order.CarOfferId);
                amount += order.Quantity * offer.UnitPrice;
            }
            return amount;

        }
    }
}
