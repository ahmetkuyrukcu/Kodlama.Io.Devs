using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers;

public class BaseController : ControllerBase
{
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    private IMediator _mediator;
}