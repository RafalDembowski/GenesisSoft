using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Addresses;
using Application.General;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AddressesController : BaseControllerController
    {
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAddresses([FromQuery] QueryParameters queryParameters)
        {
            return HandleResult(await Mediator.Send(new List.Query { Params = queryParameters }));
        }
    }
}
