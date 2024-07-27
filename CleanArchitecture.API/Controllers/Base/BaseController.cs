using Asp.Versioning;
using CleanArchitecture.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers.Base;

[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IUnityOfWork Uow;

    protected BaseController(IUnityOfWork uow)
    {
        Uow = uow;
    }
}