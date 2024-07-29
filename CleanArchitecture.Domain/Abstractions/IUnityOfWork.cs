namespace CleanArchitecture.Domain.Abstractions;

public interface IUnityOfWork
{
    IMemberEfRepository MemberEfRepository { get; }
    Task Commit();
    Task Rollback();
}