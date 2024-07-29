namespace CleanArchitecture.Domain.Abstractions.Base;

public interface IBaseWriteRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddEntity(TEntity entity);
    Task<TEntity> UpdateEntity(TEntity entity);
    Task<TEntity> DeleteEntity(int id);
}