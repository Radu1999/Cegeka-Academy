namespace Dealership.Models
{
    public class Transaction
    {
        public Transaction(string name, string address, string carVIN)
        {
            Name = name;
            Address = address;
            CarVIN = carVIN;
        }

        public string Name { get; set; }

        public string Address { get; set; }
        public string CarVIN { get; set; }
        


    }
}
