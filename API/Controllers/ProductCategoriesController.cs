using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.General;
using Application.ProductCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : BaseControllerController
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryQueryDto>>> GetProducts([FromQuery] QueryParameters queryParameters)
        {
            return HandleResult(await Mediator.Send(new List.Query { Params = queryParameters }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCategoryCommandDto product)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ProductCategory = product }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(ProductCategoryCommandDto product, Guid id)
        {
            return HandleResult(await Mediator.Send(new Update.Command { ProductCategory = product, Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpGet("dropdownItems")]
        public async Task<IActionResult> GetDropdownItems()
        {
            return HandleResult(await Mediator.Send(new Dropdowns.Query { } ));
        }
    }
}