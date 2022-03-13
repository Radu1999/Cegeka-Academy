namespace Dealership.Models
{
    public class Car
    {
        public Car(string vIN, string model)
        {
            Model = model;
            VIN = vIN;
        }

        public string Model { get; set; }

        public string VIN { get; set; }
    }
}