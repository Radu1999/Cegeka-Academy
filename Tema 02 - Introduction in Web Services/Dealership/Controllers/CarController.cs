using Microsoft.AspNetCore.Mvc;
using Dealership.Models;

namespace Dealership.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private static List<Car> DataBaseCarsSym = new List<Car>
        {
            new Car("5Z1SL65848Z411439",
                    "BMW",
                    "X6",
                    2019
                ),
             new Car("5Z7SL65848Z411439",
                     "AUDI",
                     "Q7",
                     2020
                 ),
             new Car("4Z1SL65848Z411439",
                     "BMW",
                     "X5",
                     2013
                ),
              new Car("3Z1SL65853Z411439",
                      "MERCEDES",
                      "AMG",
                      2021
                )
        };

        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCars")]
        public IEnumerable<Car> GetCars()
        {
            return DataBaseCarsSym.ToArray();
        }

        [HttpPost(Name = "AddCar")]
        public IActionResult AddCar(Car car)
        {
            if (car.Model.Length == 0
                || car.Brand.Length == 0 || car.VIN.Length == 0)
            {
                return BadRequest("Fields should not be empty");
            }
            car.VIN = car.VIN.ToUpper();
            for (int i = 0; i < DataBaseCarsSym.Count; i++)
            {
                if (DataBaseCarsSym[i].VIN == car.VIN)
                {
                    return BadRequest("Car already registered");
                }
            }

            car.Brand = car.Brand.ToUpper();
            car.Model = car.Model.ToUpper();
            DataBaseCarsSym.Add(car);
            return Ok("Car registered");
        }

        [HttpPut]
        [Route("{VIN}")]
        public IActionResult Update(string VIN, Car car)
        {
            if (car.Model.Length == 0
                || car.Brand.Length == 0 || car.VIN.Length == 0)
            {
                return BadRequest("Fields should not be empty");
            }
           
            car.VIN = car.VIN.ToUpper();

            int found = -1;

            for(int i = 0; i < DataBaseCarsSym.Count; i++)
            {
                if (DataBaseCarsSym[i].VIN == car.VIN)
                {
                    found = i;
                    break;
                }
            }
            
            if(found == -1)
            {
                return BadRequest("Car with given VIN not registered");
            }

            car.Brand = car.Brand.ToUpper();
            car.Model = car.Model.ToUpper();
            DataBaseCarsSym[found] = car;
            return Ok("Car updated");
        }

        [HttpDelete]
        [Route("VIN")]
        public IActionResult Delete(string VIN)
        {
            int found = -1;

            for (int i = 0; i < DataBaseCarsSym.Count; i++)
            {
                if (DataBaseCarsSym[i].VIN == VIN)
                {
                    found = i;
                    break;
                }
            }

            if (found == -1)
            {
                return BadRequest("Car with given VIN not registered");
            }
            DataBaseCarsSym.RemoveAt(found);
            return Ok("Car removed");
        }
    }
}