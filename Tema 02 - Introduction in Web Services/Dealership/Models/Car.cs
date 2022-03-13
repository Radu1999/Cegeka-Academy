namespace Dealership.Models
{
    public class Car
    {
        public Car(string vIN, string brand, string model, int yearModel)
        {
            Brand = brand;
            YearModel = yearModel;
            Model = model;
            VIN = vIN;
        }

        public string Brand { get; set; }

        public int YearModel { get; set; }

        public string Model { get; set; }

        public string VIN { get; set; }

        

        public override bool Equals(object? obj)
        {
            return obj is Car car &&
                   Brand == car.Brand &&
                   YearModel == car.YearModel &&
                   Model == car.Model;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Brand, YearModel, Model);
        }
    }
}