using Microsoft.AspNetCore.Mvc;
using Nsi.Application.Queries.User;

namespace Nsi.Api.Controllers;

public class UserController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUserDetails([FromQuery] string id)
    {
        return Ok(await Mediator.Send(new GetUserByIdQuery(id)));
    }
}