using Adm.Application.Features.CQRS.Commands;
using Adm.Application.Features.CQRS.Quaries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetCategoriesQueryRequest request)
        {
            return Ok(await this.mediator.Send(request));
        }

      //  [HttpGet("{id}")]

        //public async Task<IActionResult> GetById([FromQuery] GetCategoryQueryRequest request)
        //{
          //  return Ok(await this.mediator.Send(request));
        //}
        [HttpPost]
        public async Task<IActionResult>Create([FromBody] CreateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok(request);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest request )
        {
            await mediator.Send(request);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete([FromBody] DeleteCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


    }
}
