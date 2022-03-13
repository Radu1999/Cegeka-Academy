namespace Dealership.Models
{
    public class Transaction
    {
        public Transaction(string name, string address, string carModel)
        {
            Name = name;
            Address = address;
            CarModel = carModel;
        }

        public string Name { get; set; }

        public string Address { get; set; }
        public string CarModel { get; set; }
    }
}
