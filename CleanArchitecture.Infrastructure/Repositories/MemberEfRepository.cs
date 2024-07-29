using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class MemberEfRepository : IMemberEfRepository
{
    private readonly AppDbContext _context;

    public MemberEfRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Member> AddEntity(Member entity)
    {
        await _context.Members.AddAsync(entity);
        return entity;
    }

    public Task<Member> UpdateEntity(Member entity)
    {
        throw new NotImplementedException();
    }

    public Task<Member> DeleteEntity(int id)
    {
        throw new NotImplementedException();
    }
}