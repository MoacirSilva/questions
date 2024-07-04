using System.Linq.Expressions;

namespace Questao5.Domain.Repository
{
    public interface IBaseConsultRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, bool asnotracking = false);
        IQueryable<TEntity> GetQuery();
        Task<bool> ExistsAsync(Expression<Func<TEntity>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(Int64 id);
    }
}
