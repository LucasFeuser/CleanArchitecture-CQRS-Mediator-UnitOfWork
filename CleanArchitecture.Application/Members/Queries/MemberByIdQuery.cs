using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Members.Queries;

public class MemberByIdQuery : IRequest<Member>
{
    public int Id { get; private set; }

    protected MemberByIdQuery() {}
    
    public MemberByIdQuery(int id)
    {
        Id = id;
    }
}