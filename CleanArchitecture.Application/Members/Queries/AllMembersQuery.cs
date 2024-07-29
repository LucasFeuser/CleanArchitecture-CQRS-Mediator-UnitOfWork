using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CleanArchitecture.Application.Members.Queries;

public class AllMembersQuery : IRequest<IActionResult>
{ }