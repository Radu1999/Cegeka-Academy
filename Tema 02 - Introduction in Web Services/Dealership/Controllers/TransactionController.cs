using Microsoft.AspNetCore.Mvc;
using Dealership.Models;
using Dealership.Data;
using Dealership.Wrappers.Linking; 

namespace Dealership.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private LinkGenerator _linkGenerator;

        public TransactionController(ILogger<TransactionController> logger, LinkGenerator linkGenerator)
        {
            _logger = logger;
            _linkGenerator = linkGenerator;
        }

        [HttpPost]
        public IActionResult BuyCar(Transaction transaction)
        {
            if(transaction.CarModel.Length == 0 || 
                transaction.Name.Length == 0 ||
                transaction.Address.Length == 0)
            {
                return BadRequest("Fields should not be empty");
            }

            int found = -1;

            transaction.CarModel = transaction.CarModel.ToUpper();
            for(int i = 0; i < DataStorage.Instance.GetCars().Count; i++)
            {
                var car = DataStorage.Instance.GetCars()[i];
                if(car.Model == transaction.CarModel)
                {
                    found = i;
                    break;
                }

            }
            if(found == -1)
            {
                return BadRequest("Model not in stock");
            }

            transaction.Name = transaction.Name.ToUpper();
            transaction.Address = transaction.Address.ToUpper();

            DataStorage.Instance.GetCars().RemoveAt(found);
            DataStorage.Instance.CreateTransaction(transaction);

            return Ok(transaction);
        }

        [HttpGet]
        public IActionResult GetTransactions([FromQuery] int? aquisitionYear, int? pageNumber, int? pageSize)
        {
            var transactions = aquisitionYear == null ? DataStorage.Instance.GetTransactions() :
                               DataStorage.Instance.GetTransactions()
                                        .FindAll(transaction => transaction.AquisitionDate.Year == aquisitionYear);
            if(pageNumber != null)
            {
                if(pageSize == null)
                {
                    return BadRequest("You need to specify page size");
                }
                int offset = (int)((pageNumber - 1) * pageSize);
                if (offset >= transactions.Count)
                {
                    return BadRequest("Invalid pagination");
                }
                transactions = transactions.GetRange(offset, Math.Min(transactions.Count - offset, (int)pageSize));
            }
            var lw_transactions = transactions
                                .Select(transaction => new LinkWrapper<Transaction>(transaction))
                                .ToList();
            
            var transactionsWrapper = new LinkCollectionWrapper<Transaction>(lw_transactions);
            return Ok(CreateLinksForTransactions(transactionsWrapper));
        }

        private LinkCollectionWrapper<Transaction> CreateLinksForTransactions(LinkCollectionWrapper<Transaction> carsWrapper)
        {
            carsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetTransactions), values: new { }),
                    "self",
                    "GET"));
            carsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(BuyCar), values: new { }),
                    "add_transaction",
                    "POST"));

            return carsWrapper;
        }
    }
}
