using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using Application.General;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseControllerController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Entity == null) return NotFound();
            if (result.IsSuccess && result.Entity != null) return Ok(result.Entity);
            return BadRequest(result.Error);
        }

        protected ActionResult HandleResult<T>(Result<PagedList<T>> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Entity == null) return NotFound();
            if (result.IsSuccess && result.Entity != null)
            {
                Response.AddParametersPaginationHeader(result.Entity.CurrentPage , result.Entity.PageSize , result.Entity.TotalCount , result.Entity.TotalPages);
                return Ok(result.Entity);
            }
            return BadRequest(result.Error);
        }
    }
}