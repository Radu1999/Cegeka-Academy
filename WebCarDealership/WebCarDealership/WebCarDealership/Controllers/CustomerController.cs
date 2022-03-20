using Microsoft.AspNetCore.Mvc;
using CarDealership.Data.Models;
using WebCarDealership.Requests;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CustomerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Customer
            {
                Name = model.Name,
                Email = model.Email,
                Orders = model.Orders
            };

            _dbContext.Customers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerRequestModel model)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Email == model.Email);
            if(customer == null)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                customer = new Customer
                {
                    Name = model.Name,
                    Email = model.Email,
                    Orders = model.Orders
                };
                _dbContext.Customers.Add(customer);
            } else
            {
                customer.Orders = model.Orders;
                customer.Name = model.Name;
                customer.Email = model.Email;
            }

            await _dbContext.SaveChangesAsync();
            return Ok(customer);
        }
    }
}
