using Microsoft.AspNetCore.Mvc;
using Dealership.Models;
using Dealership.Data;

namespace Dealership.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult buyCar(Transaction transaction)
        {
            if(transaction.CarVIN.Length == 0 || 
                transaction.Name.Length == 0 ||
                transaction.Address.Length == 0)
            {
                return BadRequest("Fields should not be empty");
            }

            int found = -1;
            for(int i = 0; i < DataStorage.Instance.DataBaseCarsSym.Count; i++)
            {
                var car = DataStorage.Instance.DataBaseCarsSym[i];
                if(car.VIN == transaction.CarVIN)
                {
                    found = i;
                    break;
                }

            }
            if(found == -1)
            {
                return BadRequest("Car with given VIN is not registered");
            }
            DataStorage.Instance.DataBaseCarsSym.RemoveAt(found);
            DataStorage.Instance.DataBaseTransactionSym.Add(transaction);

            return Ok("Car purchased");
        }

        [HttpGet]
        public IEnumerable<Transaction> getTransactions()
        {
            return DataStorage.Instance.DataBaseTransactionSym.ToArray();
        }
    }
}
