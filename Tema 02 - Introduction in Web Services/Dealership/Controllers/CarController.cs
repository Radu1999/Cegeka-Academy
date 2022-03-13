using Microsoft.AspNetCore.Mvc;
using Dealership.Models;
using Dealership.Data;
using Dealership.Wrappers.Linking;

namespace Dealership.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        

        private readonly ILogger<CarController> _logger;
        private LinkGenerator _linkGenerator;

        public CarController(ILogger<CarController> logger, LinkGenerator linkGenerator)
        {
            _logger = logger;
            _linkGenerator = linkGenerator;
        }

        [HttpGet(Name = "GetCars")]
        public IActionResult GetCars()
        {
            var lw_cars = DataStorage.Instance.GetCars().Select(car => new LinkWrapper<Car>(car)).ToList();

            foreach (LinkWrapper<Car> lw_car in lw_cars)
            {
                var carLinks = CreateLinksForCar(lw_car.Object.VIN);
                lw_car.Links.AddRange(carLinks);

            }

            var carsWrapper = new LinkCollectionWrapper<Car>(lw_cars);
            return Ok(CreateLinksForCars(carsWrapper));
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
            for (int i = 0; i < DataStorage.Instance.GetCars().Count; i++)
            {
                if (DataStorage.Instance.GetCars()[i].VIN == car.VIN)
                {
                    return BadRequest("Car already registered");
                }
            }
            car.Model = car.Model.ToUpper();
            DataStorage.Instance.CreateCar(car);

            var carWrapper = new LinkWrapper<Car>(car);
            carWrapper.Links.AddRange(CreateLinksForCar(carWrapper.Object.VIN));

            return Ok(carWrapper);
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

            for(int i = 0; i < DataStorage.Instance.GetCars().Count; i++)
            {
                if (DataStorage.Instance.GetCars()[i].VIN == car.VIN)
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
            DataStorage.Instance.GetCars()[found] = car;

            var carWrapper = new LinkWrapper<Car>(car);
            carWrapper.Links.AddRange(CreateLinksForCar(carWrapper.Object.VIN));

            return Ok(carWrapper);
        }

        [HttpDelete]
        [Route("VIN")]
        public IActionResult Delete(string VIN)
        {
            int found = -1;

            for (int i = 0; i < DataStorage.Instance.GetCars().Count; i++)
            {
                if (DataStorage.Instance.GetCars()[i].VIN == VIN)
                {
                    found = i;
                    break;
                }
            }

            if (found == -1)
            {
                return BadRequest("Car with given VIN not registered");
            }
            DataStorage.Instance.GetCars().RemoveAt(found);
            return Ok("Car removed");
        }
        private IEnumerable<Link> CreateLinksForCar(string VIN, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(Delete), values: new { VIN }),
                "delete_car",
                "DELETE"),
                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(Update), values: new { VIN }),
                "update_car",
                "PUT")
            };
            return links;
        }

        private LinkCollectionWrapper<Car> CreateLinksForCars(LinkCollectionWrapper<Car> carsWrapper)
        {
            carsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetCars), values: new { }),
                    "self",
                    "GET"));
            carsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetCars), values: new { }),
                    "add_car",
                    "POST"));

            return carsWrapper;
        }
    }

    
}