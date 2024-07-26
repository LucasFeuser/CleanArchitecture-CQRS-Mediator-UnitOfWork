using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;

    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> GetAll()
    {
        return await _context.Members.ToListAsync();
    }

    public async Task<Member> GetById(int id)
    {
        var member = await _context.Members.FirstOrDefaultAsync(f => f.Id == id);
        if (member == null)
            throw new ArgumentNullException();
        return member;
    }

    public async Task<Member> AddEntity(Member entity)
    {
        await _context.Members.AddAsync(entity);
        return entity;
    }
}