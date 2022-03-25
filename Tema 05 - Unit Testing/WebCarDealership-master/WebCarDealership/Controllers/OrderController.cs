using CarDealership.Data.Models;
using CarDealership.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IRepository repository;

        public OrderController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offer = await repository.GetCarOfferById(model.CarOfferId);
            if (offer == null)
            {
                return NotFound("car offer not found");
            }

            if (offer.AvailableStock <= model.Quantity)
            {
                return BadRequest("Not enough cars of this model are available in stock!");
            }

            offer.AvailableStock -= model.Quantity;

            var dbOrder = new Order()
            {
                CarOfferId = model.CarOfferId,
                CustomerId = model.CustomerId,
                Date = DateTime.UtcNow,
                Quantity = model.Quantity,
                OrderAmount = model.Quantity * offer.UnitPrice
            };

            repository.AddOrder(dbOrder);

            int numberOfRecordsAffected = await repository.SaveChanges();
            if (numberOfRecordsAffected == 0)
            {
            }

            return Ok(dbOrder);
        }
    }
}
