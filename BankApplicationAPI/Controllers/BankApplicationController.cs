using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace BankApplicationAPI.Controllers
{
    [ApiController]
    public class BankApplicationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<BankApplicationController> _logger;

        public BankApplicationController(ILogger<BankApplicationController> logger)
        {
            _logger = logger;
        }

        public IHttpActionResult GetCustomerData()
        {
        }
    }
}