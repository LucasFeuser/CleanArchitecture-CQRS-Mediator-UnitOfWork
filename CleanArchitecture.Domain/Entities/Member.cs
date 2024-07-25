using CleanArchitecture.Domain.Entities.Base;

namespace CleanArchitecture.Domain.Entities;

public class Member : BaseEntity
{
    protected Member()
    { }

    public Member(int id, string? name, string? email, string? about, DateOnly birthDate, int age, bool isActive, decimal salary)
    {
        Id = id;
        Age = age;
        Name = name;
        About = about;
        Email = email;
        Salary = salary;
        IsActive = isActive;
        BirthDate = birthDate;
    }

    public string? Name { get; protected set; }
    public string? Email { get; protected set; }
    public string? About { get; protected set; }
    public DateOnly BirthDate  { get; protected set; }
    public int Age  { get; protected set; }
    public bool IsActive  { get; protected set; }
    public decimal Salary  { get; protected set; }
}