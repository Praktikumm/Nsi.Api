using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nsi.Api.Auth.Constants;
using Nsi.Application.Category.Commands;
using Nsi.Application.Common.Dto.Category;
using Nsi.Application.Queries.Category;

namespace Nsi.Api.Controllers;

public class CategoryController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategoryDetails([FromQuery] Guid id)
    {
        return Ok(await Mediator.Send(new GetCategoryByIdQuery(id)));
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderDbAuthSchema))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
    {
        return Ok(await Mediator.Send(new CreateCategoryCommand(categoryDto)));
    }
    
    [HttpDelete]
    [Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderDbAuthSchema))]
    public async Task<IActionResult> DeleteCategory([FromQuery] Guid id)
    {
        await Mediator.Send(new DeleteCategoryCommand(id));
        return Ok();
    }
}