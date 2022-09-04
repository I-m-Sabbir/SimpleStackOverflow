using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.DbContexts;
using SimpleStackOverflow.Infrastructure.Entities;

namespace SimpleStackOverflow.Infrastructure.Repositories
{
    public class VoteRepository : Repository<Vote, int>, IVoteRepository
    {
        public VoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
