using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;
using WebCarDealership.Requests;

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
        [Route("Insert")]
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
        public async Task<IActionResult> Put([FromBody] CarOfferUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(offer => (offer.Id == model.Id));
            if (offer == null)
            {
               return NotFound();
            }
            if(model.Make != null)
            {
                offer.Make = model.Make;
            }
            if(model.AvailableStock != null)
            {
                offer.AvailableStock = (int)model.AvailableStock;
            }
            if(model.Model != null)
            {
                offer.Model = model.Model;
            }
            if(model.UnitPrice != null)
            {
                offer.UnitPrice = (int)model.UnitPrice;
            }

            await _dbContext.SaveChangesAsync();
            return Ok(offer);
        }


        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] CarOfferUpdateRequestModel model)
        {
            var offer = await _dbContext.CarOffers.FindAsync(model.Id);
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