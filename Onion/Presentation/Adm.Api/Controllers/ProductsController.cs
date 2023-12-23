using Adm.Application.Features.CQRS.Commands;
using Adm.Application.Features.CQRS.Quaries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetProductsQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok(request);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody]DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
