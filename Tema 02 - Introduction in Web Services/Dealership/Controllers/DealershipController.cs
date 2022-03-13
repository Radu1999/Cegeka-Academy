using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class DealershipController : ControllerBase
    {
        private static List<Car> DataBaseSym = new List<Car>
        {
            new Car
                {
                    Brand = "BMW",
                    Model = "X6",
                    YearModel = 2019
                },
             new Car
                 {
                     Brand = "AUDI",
                     Model = "Q7",
                     YearModel = 2020
                 },
             new Car
                {
                    Brand = "BMW",
                    Model = "X5",
                    YearModel = 2013
                },
              new Car
                {
                    Brand = "MERCEDES",
                    Model = "AMG",
                    YearModel = 2021
                }
        };

        private readonly ILogger<DealershipController> _logger;

        public DealershipController(ILogger<DealershipController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCars")]
        public IEnumerable<Car> GetCars()
        {
            return DataBaseSym.ToArray();
        }

        [HttpPost(Name = "AddCar")]
        public IActionResult AddCar(Car car)
        {
            if (car.Brand == null || car.Model == null || car.Model.Length == 0
                || car.Brand.Length == 0)
            {
                return BadRequest("You must insert brand and model");
            }
            car.Brand = car.Brand.ToUpper();
            car.Model = car.Model.ToUpper();
            foreach (Car c in DataBaseSym)
            {
                if (c.Equals(car))
                {
                    return BadRequest("Car already registered");
                }
            }
            DataBaseSym.Add(car);
            return Ok("Car registered");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, Car car)
        {
            if (id >= DataBaseSym.Count)
            {
                return BadRequest("id not existent");
            }
            if (car.Brand == null || car.Model == null || car.Model.Length == 0
                || car.Brand.Length == 0)
            {
                return BadRequest("You must insert brand and model");
            }
            car.Brand = car.Brand.ToUpper();
            car.Model = car.Model.ToUpper();

            foreach (Car c in DataBaseSym)
            {
                if (c.Equals(car))
                {
                    return BadRequest("Car already registered");
                }
            }

            DataBaseSym[id] = car;
            return Ok(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >= DataBaseSym.Count)
            {
                return BadRequest("id not existent");
            }
            DataBaseSym.RemoveAt(id);
            return Ok("Car removed");
        }
    }
}