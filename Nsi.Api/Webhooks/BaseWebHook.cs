using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nsi.Api.Webhooks;

[ApiController]
[Route("webhook/[controller]/[action]")]
public class BaseWebHook : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}