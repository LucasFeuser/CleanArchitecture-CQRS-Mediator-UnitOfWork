using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Infrastructure.Context;

namespace CleanArchitecture.Infrastructure.Repositories;

public sealed class UnityOfWork(AppDbContext context) : IUnityOfWork, IDisposable
{
    private IMemberEfRepository _memberEfRepository;

    public IMemberEfRepository MemberEfRepository
    {
        get
        {
            return _memberEfRepository = new MemberEfRepository(context);
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