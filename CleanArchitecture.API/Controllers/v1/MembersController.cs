using CleanArchitecture.Application.Members.Commands;
using CleanArchitecture.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CleanArchitecture.API.Controllers.v1;

public class MembersController : BaseController
{
    public MembersController(IMediator mediator) : base(mediator)
    { }

    [HttpPost("AddMember")]
    public async Task<IActionResult> AddMember([FromBody] AddMemberCommand command) =>
        Ok(await _mediator.Send(command));
}