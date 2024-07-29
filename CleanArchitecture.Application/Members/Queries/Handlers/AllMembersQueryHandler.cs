using CleanArchitecture.CrossCutting.Common.CQRS.Query;
using CleanArchitecture.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CleanArchitecture.Application.Members.Queries.Handlers;

public class AllMembersQueryHandler : QueryBase, IRequestHandler<AllMembersQuery, IActionResult>
{
    private readonly IMemberDappRepository _memberDappRepository;

    public AllMembersQueryHandler(IMemberDappRepository memberDappRepository)
    {
        _memberDappRepository = memberDappRepository;
    }

    public async Task<IActionResult> Handle(AllMembersQuery request, CancellationToken cancellationToken)
    {
        var result = await _memberDappRepository.GetAll();

        return ReturnOk(result);
    }
}