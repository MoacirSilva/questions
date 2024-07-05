namespace Questao5.Domain.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        Task AddAsync<T>(T entity) where T : class;

        void Update(TEntity customer);

        void Update<T>(T entity) where T : class;

        void UpdateRange<T>(IEnumerable<T> entity) where T : class;

        void Remove(TEntity customer);

        void Remove<T>(T customer) where T : class;

        IUnitOfWork UnitOfWork { get; }

        IBaseConsultRepository<TEntity> RepositoryConsult { get; }
    }
}
