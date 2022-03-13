namespace Tema_02___Introduction_in_Web_Services
{
    public class Car
    {
        public string? Brand { get; set; }

        public int YearModel { get; set; }

        public string? Model { get; set; }

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