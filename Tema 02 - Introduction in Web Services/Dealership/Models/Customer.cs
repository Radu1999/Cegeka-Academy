namespace Dealership.Models
{
    public class Customer
    {
        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public string Name { get; set; }
        public string Password { get; set; }


    }
}
