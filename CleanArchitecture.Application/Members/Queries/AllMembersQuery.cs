using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Application.Members.Queries;

public class AllMembersQuery : IRequest<IActionResult>
{ }