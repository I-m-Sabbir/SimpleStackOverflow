
using SimpleStackOverflow.Infrastructure.BusinessObjects;

namespace SimpleStackOverflow.Infrastructure.Services
{
    public interface ICommentService
    {
        Task CreateAsync(Comment comment);
        Task<Comment> GetAsync(int id);
        Task VerifyCommentAsync(Comment comment);
    }
}
