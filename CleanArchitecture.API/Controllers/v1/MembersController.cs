using CleanArchitecture.API.Controllers.Base;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers.v1;

public class MembersController : BaseController
{
    public MembersController(IUnityOfWork uoW) : base(uoW)
    { }

    [HttpGet("Todos")]
    [ProducesResponseType<List<Member>>(200)]
    [ProducesResponseType<List<Member>>(400)]
    [ProducesResponseType<List<Member>>(500)]
    public async Task<IActionResult> GetAllMembers() =>
         Ok(await Uow.MemberRepository.GetAll());

    [HttpGet("PorId/{id}")]
    [ProducesResponseType<Member>(200)]
    [ProducesResponseType<Member>(400)]
    [ProducesResponseType<Member>(500)]
    public async Task<IActionResult> GetMemberById(int id) =>
        Ok(await Uow.MemberRepository.GetById(id));

    [HttpPost("Adicionar")]
    public async Task<IActionResult> AddMember([FromBody] Member member)
    {
        try
        {
            var result = await Uow.MemberRepository.AddEntity(member);
            await Uow.Commit();
            return Ok(result);
        }
        catch (Exception)
        {
            await Uow.Rollback();
            throw;
        }
    }
}