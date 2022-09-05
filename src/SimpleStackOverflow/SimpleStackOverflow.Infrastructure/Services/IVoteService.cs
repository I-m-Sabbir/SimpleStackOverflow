
using SimpleStackOverflow.Infrastructure.BusinessObjects;

namespace SimpleStackOverflow.Infrastructure.Services
{
    public interface IVoteService
    {
        Task VoteAsync(Vote vote);
        Task UpdateVoteAsync(Vote vote);
        Task DeleteVoteAsync(int commentId, Guid authorId);
    }
}
