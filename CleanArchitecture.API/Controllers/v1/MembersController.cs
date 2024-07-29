using CleanArchitecture.Application.Members.Commands;
using CleanArchitecture.Application.Members.Queries;
using CleanArchitecture.API.Controllers.Base;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MediatR;

namespace CleanArchitecture.API.Controllers.v1;

public class MembersController : BaseController
{
    public MembersController(IMediator mediator) : base(mediator)
    { }

    [HttpGet("GetAll")]
    [ProducesResponseType<Member>((int)HttpStatusCode.OK)]
    [ProducesResponseType<Member>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<Member>((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAllMembers() =>
        Ok(await Mediator.Send(new AllMembersQuery()));
    
    [HttpGet("GetAll/{id}")]
    [ProducesResponseType<Member>((int)HttpStatusCode.OK)]
    [ProducesResponseType<Member>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<Member>((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMemberById(int id) =>
        Ok(await Mediator.Send(new MemberByIdQuery(id: id)));
    
    [HttpPost("AddMember")]
    [ProducesResponseType<Member>((int)HttpStatusCode.OK)]
    [ProducesResponseType<Member>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<Member>((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> AddMember(AddMemberCommand command) =>
        Ok(await Mediator.Send(command));
}