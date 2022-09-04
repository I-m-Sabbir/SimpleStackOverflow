using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.Entities;

namespace SimpleStackOverflow.Infrastructure.Repositories
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
    }
}
