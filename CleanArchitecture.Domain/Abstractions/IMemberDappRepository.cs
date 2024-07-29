using CleanArchitecture.Domain.Abstractions.Base;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Abstractions;

public interface IMemberDappRepository : IBaseReadRepository<Member>
{ }