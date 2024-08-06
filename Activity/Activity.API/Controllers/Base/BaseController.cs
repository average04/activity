using Microsoft.AspNetCore.Mvc;

namespace Activity.API.Controllers.Base;

[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}

