using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Members.Queries;

public class MemberByIdQuery : IRequest<Member>
{
    public int Id { get; set; }

    public MemberByIdQuery(int id)
    {
        Id = id;
    }
}