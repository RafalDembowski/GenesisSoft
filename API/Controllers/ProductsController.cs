using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.General;
using Application.Products;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]  
    public class ProductsController : BaseControllerController
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductQueryDto>>> GetProducts([FromQuery] QueryParameters queryParameters)
        {
            return HandleResult(await Mediator.Send(new List.Query { Params = queryParameters }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCommandDto product)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Product = product }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(ProductCommandDto product , Guid id)
        {
            return HandleResult(await Mediator.Send(new Update.Command { Product = product , Id = id}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}