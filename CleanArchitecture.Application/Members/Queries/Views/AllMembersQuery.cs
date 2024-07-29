using System.Runtime.Serialization;
using CleanArchitecture.Application.Members.Views.Base;

namespace CleanArchitecture.Application.Members.Queries.Views;

[DataContract]
public class AllMembersQuery : MemberBase
{
    public AllMembersQuery(string? name, string? email, string? about, DateTime birthDate, int age, bool isActive, decimal salary)
    {
        Name = name;
        Email = email;
        About = about;
        BirthDate = birthDate;
        Age = age;
        IsActive = isActive;
        Salary = salary;
    }
}