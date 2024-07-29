using CleanArchitecture.Application.Members.Commands.Views;
using CleanArchitecture.CrossCutting.Common.CQRS.Command;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CleanArchitecture.Application.Members.Commands.Handlers;

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
        catch (Exception)
        {
            await _uow.Rollback();
            throw;
        }
    }
}