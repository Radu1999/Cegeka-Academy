namespace Dealership.Models
{
    public class Transaction
    {
        public Transaction(string name, string address, string carModel, DateTime aquisitionDate)
        {
            Name = name;
            Address = address;
            CarModel = carModel;
            AquisitionDate = aquisitionDate;
        }

        public string Name { get; set; }

        public string Address { get; set; }
        public string CarModel { get; set; }

        public DateTime AquisitionDate { get; set; }
    }
}
