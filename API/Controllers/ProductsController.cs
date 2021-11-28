using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.General;
using Application.Products;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class ProductsController : BaseControllerController
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAddresses([FromQuery] QueryParameters queryParameters)
        {
            return HandleResult(await Mediator.Send(new List.Query { Params = queryParameters }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(ProductDto product)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Product = product }));
        }

    }
}