using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Application.Members.Views.Base.Command;

public abstract class MemberCommandBase : MemberBase, IRequest<IActionResult> 
{ }