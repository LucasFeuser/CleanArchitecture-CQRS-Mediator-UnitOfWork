namespace CleanArchitecture.Domain.Abstractions.Base;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity> GetById(int id);
    Task<TEntity> AddEntity(TEntity entity);
}