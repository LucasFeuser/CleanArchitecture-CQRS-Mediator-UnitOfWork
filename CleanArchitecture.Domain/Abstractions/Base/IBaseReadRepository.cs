namespace CleanArchitecture.Domain.Abstractions.Base;

public interface IBaseReadRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(int id);
}