using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.DbContexts;

namespace SimpleStackOverflow.Infrastructure.UnitofWorks
{
    internal class InfrastructureUnitOfWork : UnitOfWork, IInfrastructureUnitOfWork
    {
        public InfrastructureUnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
