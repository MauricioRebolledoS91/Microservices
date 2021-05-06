using Lil.Search.Interfaces;
using Lil.Search.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Search.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        private readonly IProductsService _productsService;
        private readonly ISalesService _salesService;

        public SearchController(ICustomersService customersService, IProductsService productsService,
                                ISalesService salesService)
        {
            _customersService = customersService;
            _productsService = productsService;
            _salesService = salesService;
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)){

                return BadRequest();
            }

            try
            {
                var customer = await _customersService.GetAsync(customerId);
                var sales = await _salesService.GetAsync(customerId);

                //aquí utilizamos la creación de un objeto en tipo dinámico
                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                foreach(var sale in sales)
                {
                    foreach(var item in sale.Items)
                    {
                        var product = await _productsService.GetAsync(item.ProductId);

                        item.Product = product;
                    }
                }

                return Ok(result);
            }
            catch (Exception)
            {

            }
            return NotFound();
        }
    }
}
