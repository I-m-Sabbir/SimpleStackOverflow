using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.DbContexts;
using SimpleStackOverflow.Infrastructure.Entities;

namespace SimpleStackOverflow.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post, int>, IPostRepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
