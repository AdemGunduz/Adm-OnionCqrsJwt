using Adm.Application.Features.CQRS.UserQuery;
using Adm.Application.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("Login")]
        public async Task<IActionResult>Login([FromBody] CheckUserQueryRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsExist)
            {
                return Created("", TokenHandler.GenerateToken(result));
            }
            else
            {
                return BadRequest("Kullanıcı adi veya sifre hatali");
            }

        }
    }
}
