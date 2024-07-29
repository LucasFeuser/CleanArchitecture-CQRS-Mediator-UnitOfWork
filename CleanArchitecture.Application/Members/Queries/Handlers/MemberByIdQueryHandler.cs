using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Members.Queries.Handlers;

public class MemberByIdQueryHandler : IRequestHandler<MemberByIdQuery, Member>
{
    private readonly IMemberDappRepository _memberDappRepository;

    public MemberByIdQueryHandler(IMemberDappRepository memberDappRepository)
    {
        _memberDappRepository = memberDappRepository;
    }

    public async Task<Member> Handle(MemberByIdQuery request, CancellationToken cancellationToken) =>
        await _memberDappRepository.GetById(request.Id);
}