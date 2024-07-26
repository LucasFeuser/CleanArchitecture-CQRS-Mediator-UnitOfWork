using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Infrastructure.Context;

namespace CleanArchitecture.Infrastructure.Repositories;

public sealed class UnityOfWork : IUnityOfWork, IDisposable
{
    private IMemberRepository _memberRepository;
    private readonly AppDbContext _context;

    public UnityOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepository = new MemberRepository(_context);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    public void Dispose()
    {
        if (!_disposed)
            _context.Dispose();
        GC.SuppressFinalize(this);
    }
    
    public Task Rollback()
    {
        // Rollback anything, if necessary
        return Task.CompletedTask;
    }

}