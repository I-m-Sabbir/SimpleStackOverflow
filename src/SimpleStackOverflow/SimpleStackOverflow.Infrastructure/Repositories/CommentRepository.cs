using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.DbContexts;
using SimpleStackOverflow.Infrastructure.Entities;

namespace SimpleStackOverflow.Infrastructure.Repositories
{
    public class CommentRepository : Repository<Comment, int>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
