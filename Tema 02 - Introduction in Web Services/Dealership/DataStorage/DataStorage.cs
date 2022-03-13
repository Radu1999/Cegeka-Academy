using Dealership.Models;

namespace Dealership.Data
{
    public sealed class DataStorage
    {

        private static readonly DataStorage instance = new DataStorage();
        public List<Car> DataBaseCarsSym { get; set; }
        public List<Transaction> DataBaseTransactionSym { get; set; }
        static DataStorage()
        {
        }
        private DataStorage()
        {
            DataBaseTransactionSym = new List<Transaction>();
            DataBaseCarsSym = new List<Car>()
            {
                new Car("5Z1SL65848Z411439",
                    "BMW-X6-2019"
                ),
             new Car("5Z7SL65848Z411439",
                     "AUDI-Q7-2020"
                 ),
             new Car("4Z1SL65848Z411439",
                     "BMW-X5-2013"
                ),
              new Car("3Z1SL65853Z411439",
                      "MERCEDES-AMG-2021"
                )
            };

        }
        public static DataStorage Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
