using CleanArchitecture.API.Controllers.Base;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using log4net;

namespace CleanArchitecture.API.Controllers.v1;

public class MembersController : BaseController
{
    public MembersController(IUnityOfWork uow) : base(uow)
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
        Member result;
        try
        {
            result = await Uow.MemberRepository.AddEntity(member);
        }
        catch (Exception)
        {
            await Uow.Rollback();
            throw;
        }
        
        await Uow.Commit();
        return Ok(result);
    }

   
}