using CleanArchitecture.Domain.Abstractions.Base;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Abstractions;

public interface IMemberEfRepository : IBaseWriteRepository<Member>
{ }