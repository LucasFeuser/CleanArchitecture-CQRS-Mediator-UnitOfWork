using CleanArchitecture.Application.Members.Commands.Views;
using CleanArchitecture.CrossCutting.Common.CQRS;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Application.Members.Commands.Handler;

public class AddMemberCommandHandler : CommandBase, IRequestHandler<AddMemberCommand, IActionResult>
{
    private readonly IMemberEfRepository _memberEfRepository;
    private readonly IUnityOfWork _uow;
        
    public AddMemberCommandHandler(IMemberEfRepository memberEfRepository, IUnityOfWork uow)
    {
        _memberEfRepository = memberEfRepository;
        _uow = uow;
    }

    public async Task<IActionResult> Handle(AddMemberCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newMember = new Member(request.Name, request.Email, request.About, request.BirthDate, request.Age, request.IsActive, request.Salary);

            await _memberEfRepository.AddEntity(newMember);
            await _uow.Commit();

            return ReturnOk(new AddMemberCommandView(newMember.Name));
        }
        catch (Exception e)
        {
            await _uow.Rollback();
            Console.WriteLine(e);
            throw;
        }
    }
}