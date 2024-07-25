namespace CleanArchitecture.Domain.Abstractions.Base;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAll();
    Task<TEntity> GetById(int id);
    Task<TEntity> GetEntity(TEntity entity);
}