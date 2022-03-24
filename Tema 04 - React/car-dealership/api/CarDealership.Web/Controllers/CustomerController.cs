using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Web.Requests;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CustomerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Customers.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequestModel customer)
        {
            var dbModel = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
            };

            _dbContext.Customers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

    }
}
