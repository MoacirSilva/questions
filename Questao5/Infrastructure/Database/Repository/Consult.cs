using Dapper;
using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Database.Context;
using System.Linq.Expressions;

namespace Questao5.Infrastructure.Database.Repository
{
    public class Consult<TEntity> : IBaseConsultRepository<TEntity> where TEntity : class
    {
        readonly AppliContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Consult(AppliContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Dispose() => GC.SuppressFinalize(this);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.AnyAsync(predicate);
        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(string sql, object par = null)
                                                                           => await _context.Database.GetDbConnection().QueryAsync<TModel>(sql, par);
        public async Task<TModel> GetOneAsync<TModel>(string sql, object obj = null)
                                                                           => await _context.Database.GetDbConnection().QueryFirstAsync<TModel>(sql, obj);
       
        public async Task<TEntity> FindByIdAsync(Int64 id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, bool asnotracking = false)
            => asnotracking == true ? await _dbSet.Where(predicate).AsNoTracking().ToListAsync() : await _dbSet.Where(predicate).ToListAsync();
        public IQueryable<TEntity> GetQuery() => _dbSet.AsQueryable();
       
    }
}
