using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesProvider _salesProvider;

        public SalesController(ISalesProvider salesProvider)
        {
            _salesProvider = salesProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var orders = await _salesProvider.GetAsync(customerId);

            if(orders != null && orders.Any())
            {
                return Ok(orders);
            }

            return NotFound();
        }
    }
}
