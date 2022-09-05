
using SimpleStackOverflow.Infrastructure.BusinessObjects;

namespace SimpleStackOverflow.Infrastructure.Services
{
    public interface ICommentService
    {
        Task CreateAsync(Comment comment);
    }
}
