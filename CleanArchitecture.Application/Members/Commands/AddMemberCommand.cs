using CleanArchitecture.Application.Members.Views.Base.Command;

namespace CleanArchitecture.Application.Members.Commands;

public class AddMemberCommand : MemberCommandBase
{
    protected AddMemberCommand() {}
    
    public AddMemberCommand(string name, string email, string about, DateTime birthDate, int age, bool isActive, decimal salary)
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