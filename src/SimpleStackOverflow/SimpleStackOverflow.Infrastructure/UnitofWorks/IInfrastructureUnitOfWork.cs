using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.Repositories;

namespace SimpleStackOverflow.Infrastructure.UnitofWorks
{
    public interface IInfrastructureUnitOfWork : IUnitOfWork
    {
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        IVoteRepository Votes { get; }
    }
}
