using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Members.Commands;

public class AddMemberCommand : IRequest<Member>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? About { get; set; }
    public DateTime BirthDate { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public decimal Salary { get; set; }

    public class AddMemberCommandHandler : IRequestHandler<AddMemberCommand, Member>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnityOfWork _uow;

        public AddMemberCommandHandler(IMemberRepository memberRepository, IUnityOfWork uow)
        {
            _memberRepository = memberRepository;
            _uow = uow;
        }

        public async Task<Member> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newMember = new Member(request.Name, request.Email, request.About, request.BirthDate, request.Age, request.IsActive, request.Salary);

                await _memberRepository.AddEntity(newMember);
                await _uow.Commit();

                return newMember;
            }
            catch (Exception e)
            {
                await _uow.Rollback();
                Console.WriteLine(e);
                throw;
            }
        }
    }
}