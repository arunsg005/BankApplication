using ConsoleApp2;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace BankApplicationController.Controllers
{
    [ApiController]
    public class BankApplicationController : ApiController
    {
      

        private readonly ILogger<BankApplicationController> _logger;

        public BankApplicationController(ILogger<BankApplicationController> logger)
        {
            _logger = logger;
        }

        public IHttpActionResult GetCustomers()
        {
            Console.WriteLine("Customer Data:");
            
            return Ok(BankApplication.customers.Values);
        }

        public IHttpActionResult GetBankAccountData()
        {
            Console.WriteLine("Bank Account Data:");

            return Ok(BankApplication.bankAccounts.Values);
        }
    }
}