using Microsoft.AspNetCore.Mvc;
using Dealership.Models;
using Dealership.Data;

namespace Dealership.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        

        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCars")]
        public IEnumerable<Car> GetCars()
        {
            return DataStorage.Instance.DataBaseCarsSym.ToArray();
        }

        [HttpPost(Name = "AddCar")]
        public IActionResult AddCar(Car car)
        {
            if (car.Model.Length == 0
                || car.VIN.Length == 0)
            {
                return BadRequest("Fields should not be empty");
            }
            car.VIN = car.VIN.ToUpper();
            for (int i = 0; i < DataStorage.Instance.DataBaseCarsSym.Count; i++)
            {
                if (DataStorage.Instance.DataBaseCarsSym[i].VIN == car.VIN)
                {
                    return BadRequest("Car already registered");
                }
            }
            car.Model = car.Model.ToUpper();
            DataStorage.Instance.DataBaseCarsSym.Add(car);
            return Ok("Car registered");
        }

        [HttpPut]
        [Route("{VIN}")]
        public IActionResult Update(string VIN, Car car)
        {
            if (car.Model.Length == 0
                || car.VIN.Length == 0)
            {
                return BadRequest("Fields should not be empty");
            }
           
            car.VIN = car.VIN.ToUpper();

            int found = -1;

            for(int i = 0; i < DataStorage.Instance.DataBaseCarsSym.Count; i++)
            {
                if (DataStorage.Instance.DataBaseCarsSym[i].VIN == car.VIN)
                {
                    found = i;
                    break;
                }
            }
            
            if(found == -1)
            {
                return BadRequest("Car with given VIN not registered");
            }
            car.Model = car.Model.ToUpper();
            DataStorage.Instance.DataBaseCarsSym[found] = car;
            return Ok("Car updated");
        }

        [HttpDelete]
        [Route("VIN")]
        public IActionResult Delete(string VIN)
        {
            int found = -1;

            for (int i = 0; i < DataStorage.Instance.DataBaseCarsSym.Count; i++)
            {
                if (DataStorage.Instance.DataBaseCarsSym[i].VIN == VIN)
                {
                    found = i;
                    break;
                }
            }

            if (found == -1)
            {
                return BadRequest("Car with given VIN not registered");
            }
            DataStorage.Instance.DataBaseCarsSym.RemoveAt(found);
            return Ok("Car removed");
        }
    }
}