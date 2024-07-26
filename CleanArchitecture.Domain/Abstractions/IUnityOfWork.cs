namespace CleanArchitecture.Domain.Abstractions;

public interface IUnityOfWork
{
    IMemberRepository MemberRepository { get; }
    Task Commit();
    Task Rollback();
}