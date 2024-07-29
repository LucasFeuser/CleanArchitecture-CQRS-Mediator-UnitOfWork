using CleanArchitecture.Application.Members.Views.Base.View;

namespace CleanArchitecture.Application.Members.Commands.Views;

public class AddMemberCommandView : MemberViewBase
{
    protected AddMemberCommandView()
    { }

    public AddMemberCommandView(string? name)
    {
        Name = name;
    }
}
