using Microsoft.AspNetCore.Mvc;

namespace Tema_02___Introduction_in_Web_Services.Controllers
{
    [ApiController]
    [Route("api/v1/cars")]
    public class DealershipController : ControllerBase
    {
        private static List<Car> DataBaseSym = new List<Car>
        {
            new Car("5Z1SL65848Z411439")
                {
                    Brand = "BMW",
                    Model = "X6",
                    YearModel = 2019
                },
             new Car("4Y1SL65848Z411439")
                 {
                     Brand = "AUDI",
                     Model = "Q7",
                     YearModel = 2020
                 },
             new Car("4Y1SM65848Z411439")
                {
                    Brand = "BMW",
                    Model = "X5",
                    YearModel = 2013
                },
              new Car("4Y1ML65848Z411439")
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

            car.VIN = car.VIN.ToUpper();
           
            foreach (Car c in DataBaseSym)
            {
                if (c.VIN == car.VIN)
                {
                    return BadRequest("Car already registered");
                }
            }

            car.Brand = car.Brand.ToUpper();
            car.Model = car.Model.ToUpper();
            DataBaseSym.Add(car);
            return Ok("Car registered");
        }

        [HttpPut]
        [Route("{VIN}")]
        public IActionResult Update(string VIN, Car car)
        {
            if (car.Brand == null || car.Model == null || car.Model.Length == 0
                || car.Brand.Length == 0)
            {
                return BadRequest("You must insert brand and model");
            }
            car.VIN = car.VIN.ToUpper();
           

            int found = -1;

            for(int i = 0; i < DataBaseSym.Count; i++)
            {
                if (DataBaseSym[i].VIN == car.VIN)
                {
                    found = i;
                    break;
                }
            }
            
            if(found == -1)
            {
                return BadRequest("Car with given VIN is not registered");
            }

            car.Brand = car.Brand.ToUpper();
            car.Model = car.Model.ToUpper();

            DataBaseSym[found] = car;
            return Ok("Car updated");
        }

        [HttpDelete]
        [Route("{VIN}")]
        public IActionResult Delete(string VIN)
        {
            int found = -1;
            for (int i = 0; i < DataBaseSym.Count; i++)
            {
                if (DataBaseSym[i].VIN == VIN)
                {
                    found = i;
                    break;
                }
            }

            if (found == -1)
            {
                return BadRequest("Car with given VIN is not registered");
            }

            DataBaseSym.RemoveAt(found);

            return Ok("Car removed");
        }
    }
}