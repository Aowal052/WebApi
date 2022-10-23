using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using WebApi.Application.CommandQuery.Accounts.Queries.Login;

namespace WebApiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _iMediator;

        public AccountsController(IMediator iMediator)
        {
            _iMediator = iMediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
        {
            var token = await _iMediator.Send(command);
            return Ok(token);
        }
    }
}
