using System.Text.Json.Serialization;

namespace Dealership.Models
{
    public class Car
    {
        [JsonConstructorAttribute]
        public Car(string vIN, string model)
        {
            Model = model;
            VIN = vIN;
        }

        public Car(Car car)
        {
            VIN = car.VIN;
            Model = car.Model;
        }

        public string Model { get; set; }

        public string VIN { get; set; }
    }
}