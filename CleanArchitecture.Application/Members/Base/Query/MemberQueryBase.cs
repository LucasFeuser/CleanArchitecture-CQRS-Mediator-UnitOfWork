using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Application.Members.Views.Base.Query;

public class MemberQueryBase : MemberBase, IRequest<IActionResult>
{
    
}