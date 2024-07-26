using System.Xml.Serialization;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MemberMapping());
    }
    
    public DbSet<Member> Members { get; set; }
}