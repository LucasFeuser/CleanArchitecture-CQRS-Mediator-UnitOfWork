using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CleanArchitecture.API.Controllers.Base;

[Route("api/v1/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator Mediator;

    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}