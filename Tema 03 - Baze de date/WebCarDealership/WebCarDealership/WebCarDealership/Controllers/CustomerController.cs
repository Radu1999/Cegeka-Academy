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
        public async Task<IActionResult> Put([FromBody] CustomerUpdateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(customer => (customer.Id == model.Id));
            if(customer == null)
            {
                return NotFound();
            }

            if(model.Name != null)
            {
                customer.Name = model.Name;
            }

            if (model.Email != null)
            {
                customer.Email = model.Email;
            }
            await _dbContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var customer = await _dbContext.Customers.FindAsync(Id);
            if(customer == null)
            {
                return NotFound();
            }
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return Ok(customer);
        }
    }
}
