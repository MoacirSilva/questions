using Microsoft.EntityFrameworkCore;
using Questao5.Infrastructure.Database.Mapping;

namespace Questao5.Infrastructure.Database.Context
{
    public class AppliContext : DbContext 
    {
        public AppliContext(DbContextOptions<AppliContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CheckAccountMap());
        }
    }
}
