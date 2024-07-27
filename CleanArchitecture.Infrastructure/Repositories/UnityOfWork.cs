using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Infrastructure.Context;

namespace CleanArchitecture.Infrastructure.Repositories;

public sealed class UnityOfWork(AppDbContext context) : IUnityOfWork, IDisposable
{
    private IMemberRepository _memberRepository;

    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepository = new MemberRepository(context);
        }
    }

    public async Task Commit()
    {
        await context.SaveChangesAsync();
    }

    private bool  _disposed = false;

    ~UnityOfWork() =>
        Dispose();
    
    public void Dispose()
    {
        if (!_disposed)
            context.Dispose();
        GC.SuppressFinalize(this);
    }
    
    public Task Rollback()
    {
        // Rollback anything, if necessary
        return Task.CompletedTask;
    }

}