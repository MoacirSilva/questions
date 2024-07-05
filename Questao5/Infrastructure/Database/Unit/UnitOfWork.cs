using Questao5.Domain.Repository;
using Questao5.Infrastructure.Database.Context;

namespace Questao5.Infrastructure.Database.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppliContext _appliContext;
        public UnitOfWork(AppliContext appliContext)
        {
            _appliContext = appliContext;
        }
        public void Dispose() => GC.SuppressFinalize(this);
        public async Task<bool> CommitAsync() => await _appliContext.SaveChangesAsync() > 0;
    }
}
