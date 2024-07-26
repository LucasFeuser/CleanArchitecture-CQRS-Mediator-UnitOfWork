using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Mapping;

public class MemberMapping : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("t_members");

        builder.HasKey(k => k.Id);
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.Age).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.About).IsRequired();
        builder.Property(p => p.Salary).IsRequired();
        builder.Property(p => p.BirthDate).IsRequired();
        builder.Property(p => p.IsActive).IsRequired();
        
        builder.HasData(
            new Member(1, "Lucas Feuser", "lucasvinchfeuser@gmail.com", "Sobre mim: Eu sou eu", DateTime.Now, 25, true, 5000)
        );
    }
}