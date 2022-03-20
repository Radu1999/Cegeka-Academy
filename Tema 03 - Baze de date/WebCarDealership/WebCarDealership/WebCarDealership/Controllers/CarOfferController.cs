using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarOfferController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CarOfferController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _dbContext.CarOffers.ToListAsync();
            return Ok(offers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarOfferRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock,
                UnitPrice = model.UnitPrice,
            };

            _dbContext.CarOffers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarOfferRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(offer => (model.Id != null && offer.Id == model.Id));
            if (offer == null)
            {
                offer = new CarOffer
                {
                    Make = model.Make,
                    Model = model.Model,
                    AvailableStock= model.AvailableStock
                };
                _dbContext.CarOffers.Add(offer);
            }
            else
            {
                offer.Make = model.Make;
                offer.Model = model.Model;
                offer.AvailableStock = model.AvailableStock;
            }

            await _dbContext.SaveChangesAsync();
            return Ok(offer);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var offer = await _dbContext.CarOffers.FindAsync(Id);
            if (offer == null)
            {
                return NotFound();
            }
            _dbContext.CarOffers.Remove(offer);
            await _dbContext.SaveChangesAsync();

            return Ok(offer);
        }
    }
}