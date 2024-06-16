using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nsi.Api.Auth.Constants;
using Nsi.Application.Category.Commands;
using Nsi.Application.Common.Dto.Category;

namespace Nsi.Api.Webhooks;

public class Category : BaseWebHook
{
    [HttpPost]
    [Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderDbAuthSchema))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
    {
        return Ok(await Mediator.Send(new CreateCategoryCommand(categoryDto)));
    }
}